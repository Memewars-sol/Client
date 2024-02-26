﻿namespace Summoners.Memewars
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Newtonsoft.Json;
    // using static Web3Auth;
    using System.Collections;
    using UnityEngine.SceneManagement;
    using Summoners.RealtimeNetworking.Client;

    public class Web3AuthImplement : MonoBehaviour
    {
        List<LoginVerifier> verifierList = new List<LoginVerifier> {
            new LoginVerifier("Google", Provider.GOOGLE),
            new LoginVerifier("Facebook", Provider.FACEBOOK),
            // new LoginVerifier("CUSTOM_VERIFIER", Provider.CUSTOM_VERIFIER),
            new LoginVerifier("Twitch", Provider.TWITCH),
            new LoginVerifier("Discord", Provider.DISCORD),
            new LoginVerifier("Reddit", Provider.REDDIT),
            new LoginVerifier("Apple", Provider.APPLE),
            new LoginVerifier("Github", Provider.GITHUB),
            new LoginVerifier("LinkedIn", Provider.LINKEDIN),
            new LoginVerifier("Twitter", Provider.TWITTER),
            new LoginVerifier("Line", Provider.LINE),
            // new LoginVerifier("Hosted Email Passwordless", Provider.EMAIL_PASSWORDLESS),
        };

        static Web3Auth web3Auth;

        [SerializeField] InputField emailAddressField;
        [SerializeField] Dropdown verifierDropdown;
        [SerializeField] Button loginButton;
        [SerializeField] Text loginResponseText;
        [SerializeField] Button logoutButton;
        [SerializeField] private int gameSceneIndex = 1;
        [SerializeField] Image authPageLogo = null;
        [SerializeField] private Image progressBar = null;
        [SerializeField] private GameObject _loadingPanel = null;
        private float realLoadPortion = 0.8f;
        private float minLoadTime = 2f;

        void Start()
        {
            var loginConfigItem = new LoginConfigItem()
            {
                verifier = "your_verifierid_from_web3auth_dashboard",
                typeOfLogin = TypeOfLogin.GOOGLE,
                clientId = "BDB4CGOrwGqh2wbcMGx1TFUdVNioekJ1K4cZKCXLhNvv1_TxNYgOWWoS_zzpuWpVkfefmJ1WwZPc05jTkP99K1U"
            };

            web3Auth = GetComponent<Web3Auth>();
            web3Auth.setOptions(new Web3AuthOptions()
            {
                whiteLabel = new WhiteLabelData()
                {
                    appName = "Meme Wars",
                    logoLight = null,
                    logoDark = null,
                    // defaultLanguage = "en",
                    // mode = "dark",
                    theme = new Dictionary<string, string>
                    {
                        { "primary", "#123456" }
                    }
                },
                // If using your own custom verifier, uncomment this code.
                /*
                ,
                loginConfig = new Dictionary<string, LoginConfigItem>
                {
                    {"CUSTOM_VERIFIER", loginConfigItem}
                }
                */
                clientId = "BDB4CGOrwGqh2wbcMGx1TFUdVNioekJ1K4cZKCXLhNvv1_TxNYgOWWoS_zzpuWpVkfefmJ1WwZPc05jTkP99K1U",
                // buildEnv = BuildEnv.TESTING,
                redirectUrl = new Uri("torusapp://com.torus.Web3AuthUnity/auth"),
                network = Web3Auth.Network.TESTNET,
                sessionTime = 86400
            });
            web3Auth.onLogin += onLogin;
            web3Auth.onLogout += onLogout;

            // emailAddressField.gameObject.SetActive(false);
            logoutButton.gameObject.SetActive(false);
            _loadingPanel.gameObject.SetActive(false);

            loginButton.onClick.AddListener(login);
            logoutButton.onClick.AddListener(logout);

            verifierDropdown.AddOptions(verifierList.Select(x => x.name).ToList());
            verifierDropdown.onValueChanged.AddListener(onVerifierDropDownChange);

            progressBar.fillAmount = 0;

            // RealtimeNetworking.OnPacketReceived += ReceivedPaket;
            RealtimeNetworking.OnConnectingToServerResult += ConnectionResponse;
            RealtimeNetworking.Connect();
        }

        private void ConnectionResponse(bool successful)
        {
            RealtimeNetworking.OnConnectingToServerResult -= ConnectionResponse;
            if (successful)
            {
                if (PlayerPrefs.HasKey(Player.password_key))
                {
                    loginButton.gameObject.SetActive(false);
                    verifierDropdown.gameObject.SetActive(false);
                    authPageLogo.gameObject.SetActive(false);
                    web3Auth.gameObject.SetActive(true);
                    Authenticate();
                }
            }
        }

        private void onLogin(Web3AuthResponse response)
        {
            loginResponseText.text = JsonConvert.SerializeObject(response, Formatting.Indented);
            var userInfo = JsonConvert.SerializeObject(response.userInfo, Formatting.Indented);
            Debug.Log(response);

            // {
            //     "ed25519PrivKey": "666523652352635....",
            //     "privKey": "0ajjsdsd....",
            //     "coreKitKey": "0ajjsdsd....",
            //     "coreKitEd25519PrivKey": "666523652352635....",
            //     "sessionId": "....",
            //     "error": "....",
            //     "userInfo": {
            //         "aggregateVerifier": "w3a-google",
            //         "email": "john@gmail.com",
            //         "name": "John Dash",
            //         "profileImage": "https://lh3.googleusercontent.com/a/Ajjjsdsmdjmnm...",
            //         "typeOfLogin": "google",
            //         "verifier": "torus",
            //         "verifierId": "john@gmail.com",
            //         "dappShare": "<24 words seed phrase>", // will be sent only incase of custom verifiers
            //         "idToken": "<jwtToken issued by Web3Auth>",
            //         "oAuthIdToken": "<jwtToken issued by OAuth Provider>", // will be sent only incase of custom verifiers
            //         "oAuthAccessToken": "<accessToken issued by OAuth Provider>", // will be sent only incase of custom verifiers
            //         "isMfaEnabled": true // returns true if user has enabled mfa
            //     }
            // }

            loginButton.gameObject.SetActive(false);
            verifierDropdown.gameObject.SetActive(false);
            authPageLogo.gameObject.SetActive(false);
            // emailAddressField.gameObject.SetActive(false);
            // logoutButton.gameObject.SetActive(true);

            PlayerPrefs.SetString(Player.password_key, Data.EncodeString(response.privKey));
            PlayerPrefs.SetString(Player.username_key, Data.EncodeString(response.privKey));
            PlayerPrefs.SetString(Player.device_id, response.privKey);

            Authenticate();
        }

        private void Authenticate()
        {
            _loadingPanel.gameObject.SetActive(true);
            StartCoroutine(LoadGame());
        }

        private void onLogout()
        {
            loginButton.gameObject.SetActive(true);
            verifierDropdown.gameObject.SetActive(true);
            logoutButton.gameObject.SetActive(false);

            loginResponseText.text = "";
        }


        private void onVerifierDropDownChange(int selectedIndex)
        {
            // if (verifierList[selectedIndex].loginProvider == Provider.EMAIL_PASSWORDLESS)
            //     emailAddressField.gameObject.SetActive(true);
            // else
            //     emailAddressField.gameObject.SetActive(false);
        }

        private void login()
        {
            var selectedProvider = verifierList[verifierDropdown.value].loginProvider;

            var options = new LoginParams()
            {
                loginProvider = selectedProvider,
                curve = Curve.ED25519
            };

            if (selectedProvider == Provider.EMAIL_PASSWORDLESS)
            {
                options.extraLoginOptions = new ExtraLoginOptions()
                {
                    login_hint = emailAddressField.text
                };
            }

            web3Auth.login(options);
        }

        private void logout()
        {
            web3Auth.logout();
        }


        // game side
        private IEnumerator LoadGame()
        {
            float loadingTimer = Time.realtimeSinceStartup;
            yield return new WaitForEndOfFrame();
            bool done = false;
            AsyncOperation async = SceneManager.LoadSceneAsync(gameSceneIndex);
            async.allowSceneActivation = false;
            while (!async.isDone && !done)
            {
                float progress = Mathf.Clamp01(async.progress / 0.9f) * realLoadPortion;
                progressBar.fillAmount = progress;
                // progressText.text = progress * 100f + "%";
                if (async.progress >= 0.9f)
                {
                    done = true;
                }
                yield return null;
            }
            float remained = minLoadTime - (Time.realtimeSinceStartup - loadingTimer);
            while (remained > 0)
            {
                float progress = realLoadPortion + ((1f - realLoadPortion) * (1f - (remained / minLoadTime)));
                progressBar.fillAmount = progress;
                remained -= Time.deltaTime;
                yield return null;
            }
            progressBar.fillAmount = 1;
            async.allowSceneActivation = true;
        }
    }
}