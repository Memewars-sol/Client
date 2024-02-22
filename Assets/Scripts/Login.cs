

namespace Summoners.Memewars
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using Solana.Unity.Wallet;
    using Solana.Unity.SDK;
    using System.Text;
    using System;
    using WebUtils;
    using UnityEngine.SceneManagement;
    using System.Collections;
    using Summoners.RealtimeNetworking.Client;
    using Solana.Unity.Wallet.Bip39;

    public class LoginScreen : MonoBehaviour
    {

        [Header("Loading")]
        [SerializeField] private int gameSceneIndex = 1;
        [SerializeField] private Image progressBar = null;
        // [SerializeField] private TextMeshProUGUI progressText = null;

        [Header("Auth")]
        [SerializeField] private GameObject _termsPanel = null;
        [SerializeField] private GameObject _loadingPanel = null;
        [SerializeField] private GameObject _loginPanel = null;

        [SerializeField]
        private TMP_InputField passwordInputField;
        [SerializeField]
        private TextMeshProUGUI passwordText;
        [SerializeField]
        private Button loginBtn; 
        [SerializeField]
        private Button loginBtnGoogle;
        [SerializeField]
        private Button loginBtnTwitter;
        [SerializeField]
        private Button loginBtnWalletAdapter;
        [SerializeField]
        private Button loginBtnSms;
        [SerializeField]
        private Button loginBtnXNFT;
        [SerializeField]
        private TextMeshProUGUI messageTxt;
        [SerializeField]
        private TMP_Dropdown dropdownRpcCluster;

        private bool IsWallet = false;
        private float minLoadTime = 2f;
        private float realLoadPortion = 0.8f;

        private void OnEnable()
        {
        }

        private void Start()
        {
            // passwordText.text = "";

            // passwordInputField.onSubmit.AddListener(delegate { LoginChecker(); });

            // loginBtn.onClick.AddListener(LoginChecker);
            loginBtnGoogle.onClick.AddListener(delegate{LoginCheckerWeb3Auth(Provider.GOOGLE);});
            loginBtnTwitter.onClick.AddListener(delegate{LoginCheckerWeb3Auth(Provider.TWITTER);});
            loginBtnWalletAdapter.onClick.AddListener(LoginCheckerWalletAdapter);
            // loginBtnSms.onClick.AddListener(LoginCheckerSms);
            // loginBtnXNFT.onClick.AddListener(LoginCheckerWalletAdapter);
            
            // loginBtnXNFT.gameObject.SetActive(false);

            if (Application.platform is RuntimePlatform.LinuxEditor or RuntimePlatform.WindowsEditor or RuntimePlatform.OSXEditor)
            {
                loginBtnWalletAdapter.onClick.RemoveListener(LoginCheckerWalletAdapter);
                loginBtnWalletAdapter.onClick.AddListener(() =>
                    Debug.LogWarning("Wallet adapter login is not yet supported in the editor"));
            }
            
            RealtimeNetworking.OnPacketReceived += ReceivedPaket;
            RealtimeNetworking.OnConnectingToServerResult += ConnectResult;
            RealtimeNetworking.Connect();

        }
        private async void LoginTest()
        {
            var password = "asdasd";
            var account = await Web3.Instance.LoginInGameWallet(password);
            if(account == null) {
                var mnemonic = new Mnemonic(WordList.English, WordCount.TwentyFour).ToString();
                account = await Web3.Instance.CreateAccount(mnemonic, password);
            }
            CheckAccount(account);
        }

        private async void LoginCheckerSms()
        {
            var account = await Web3.Instance.LoginWalletAdapter();
            CheckAccount(account);
        }
        
        private async void LoginCheckerWeb3Auth(Provider provider)
        {
            var account = await Web3.Instance.LoginWeb3Auth(provider);
            IsWallet = false;
            CheckAccount(account);
        }

        private async void LoginCheckerWalletAdapter()
        {
            if(Web3.Instance == null) return;
            var account = await Web3.Instance.LoginWalletAdapter();
            IsWallet = true;
            CheckAccount(account);
        }


        private async void CheckAccount(Account account)
        {
            // the message that we have to sign
            byte[] message = Encoding.UTF8.GetBytes(Requests.AUTH_MESSAGE);

            // sign using wallet adapter or directly sign using the private key we obtained from web3auth
            // IsWallet = using phantom etc, !IsWallet = using Web3Auth
            // only works on phantom for now
            byte[] signed = IsWallet? await Web3.Instance.WalletBase.SignMessage(message) : account.Sign(message);

            // verify this signature in backend
            string signature = Convert.ToBase64String(signed);

            // need to change this url
            // string url = "http://localhost:8081/api/";

            string address = account.PublicKey.ToString();

            // set player's settings
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString(Player.address_key, address);
            PlayerPrefs.SetString(Player.signature_key, signature);

            // Authenticate, CreateAccount, and LoadGame
            /* var request = await Requests.Post(url);

            if (request.result == UnityWebRequest.Result.Success)
            {
                StartCoroutine(LoadGame());
            } */ 

            // send for authentication
            var packet = new Packet((int)Player.RequestsID.PREAUTH);
            Sender.TCP_Send(packet);
        }

        /* public void OnClose()
        {
            // var wallet = GameObject.Find("wallet");
            // wallet.SetActive(false);
        } */

        private void ConnectResult(bool successful)
        {
            if (successful)
            {
                // auto login test account
                LoginTest();
                Debug.Log("Connected to server successfully.");

            }
            else
            {
                Debug.Log("Failed to connect the server.");
            }
        }

        private void ReceivedPaket(Packet packet)
        {
            try
            {
                int id = packet.ReadInt();
                switch ((Player.RequestsID)id) {
                    case Player.RequestsID.PREAUTH:
                        bool IsVerified = packet.ReadInt() == 1;

                        // load game if verified in preauth
                        if(IsVerified) 
                            StartCoroutine(LoadGame());
                        else
                            Debug.Log("Signature mismatch");
                        break;

                    default:
                        Debug.Log((Player.RequestsID)id);
                        break;
                    
                }
            }
            catch (Exception exception)
            {
                Debug.Log(exception.ToString());
            }
        }

        private void OnDestroy()
        {
            RealtimeNetworking.OnPacketReceived -= ReceivedPaket;
        }

        
        private IEnumerator LoadGame()
        {
            _loadingPanel.gameObject.SetActive(true);
            _loginPanel.gameObject.SetActive(false);

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

        private void OnLevelWasLoaded(int level)
        {
            Destroy(gameObject);
        }
    }
}
