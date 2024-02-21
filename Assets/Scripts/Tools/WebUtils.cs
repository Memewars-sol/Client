using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Solana.Unity.Soar.Accounts;
using System.Dynamic;

namespace WebUtils
{
    public class Requests {
        public static readonly string AUTH_MESSAGE = "Auth this message";

        // https://forum.unity.com/threads/unitywebrequest-post-url-jsondata-sending-broken-json.414708/
        public static async Task<UnityWebRequest> Post(string url, Dictionary<string, object> jsonObject)
        {
            string address = PlayerPrefs.GetString(Summoners.Memewars.Player.address_key);
            string signature = PlayerPrefs.GetString(Summoners.Memewars.Player.signature_key);

            // for auth purposes, even if the route doesn't require authentication
            jsonObject["address"] = address;
            jsonObject["signature"] = signature;
            jsonObject["message"] = AUTH_MESSAGE;

            string bodyJsonString = JsonConvert.SerializeObject(jsonObject);
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            await request.SendWebRequest();
            return request;
        }
        
        public static async Task<UnityWebRequest> Post(string url)
        {
            // for auth purposes, even if the route doesn't require authentication
            Dictionary<string, object> jsonObject = new Dictionary<string, object>();
            return await Post(url, new Dictionary<string, object>());
        }
    }
}