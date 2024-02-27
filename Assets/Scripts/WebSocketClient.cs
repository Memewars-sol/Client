namespace Summoners.RealtimeNetworking.WsClient
{

    using UnityEngine;
    using WebSocketSharp;
    using System.Threading;
    using Newtonsoft.Json;



    public class WebSocketClient : MonoBehaviour
    {
        public static event OnMessageCallback OnMessageReceived;
        public delegate void OnMessageCallback(object sender, MessageEventArgs e);

        private static WebSocketClient instance;

        private WebSocket ws;

        // URL of the WebSocket server
        [SerializeField]
        private string serverUrl = "ws://127.0.0.1:8080/Echo";

        public static void RaiseOnMessage(object sender, MessageEventArgs e)
        {
            if (OnMessageReceived != null)
            {
                OnMessageReceived?.Invoke(sender, e);
            }
        }

        private void Awake()
        {
            Debug.Log("Websocket awake!");
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Debug.Log("Attempt to start websocket");
            // Connect to the WebSocket server
            Connect();
            // ... add similar lines for other packet types (Boolean, Vector3, etc.)
        }


        // onDestroy doesn't work in unity
        // private void OnDestroy()
        private void OnApplicationQuit()
        {
            // Disconnect from the WebSocket server when the GameObject is destroyed
            Disconnect();
        }

        private void Connect()
        {
            // Create a new WebSocket instance
            ws = new WebSocket(serverUrl);
            ws.Log.Level = LogLevel.Trace;
            ws.Log.File = "/Users/lucas/Documents/coc/ws.log";

            // Add event handlers
            ws.OnOpen += OnOpen;
            ws.OnMessage += OnMessage;
            ws.OnError += OnError;
            ws.OnClose += OnClose;

            // Connect to the WebSocket server
            ws.Connect();
        }

        private void Disconnect()
        {
            if (ws != null && ws.ReadyState == WebSocketState.Open)
                ws.Close ();
            // if (ws != null)
            // {
            //     // Close the WebSocket connection
            //     ws.Close();
            //     ws = null;
            // }
        }

        private void OnOpen(object sender, System.EventArgs e)
        {
            Debug.Log("WebSocket connected");
        }

        public void OnMessage(object sender, MessageEventArgs e)
        {
            Debug.Log("Received message: " + e.Data);
            WebSocketClient.RaiseOnMessage(this, e); // Raise the OnMessageReceived event
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            Debug.LogError("WebSocket error: " + e.Message);
        }

        private void OnClose(object sender, CloseEventArgs e)
        {
            Debug.Log("Curr url" + serverUrl);
            Debug.Log("WebSocket closed with code: " + e.Code + ", reason: " + e.Reason);
            Thread.Sleep(10000);
            Debug.Log("Attempt to reconnect...");
            ws.Connect();
        }

        // Example method to send a message to the server
        // public void SendData(string message)
        // {
        //     if (ws != null && ws.IsAlive)
        //     {
        //         ws.Send(message);
        //     }
        //     else
        //     {
        //         Debug.LogWarning("WebSocket is not connected");
        //     }
        // }

        public void SendData(dynamic packet)
        {
            // Serialize the Packet object to JSON
            string json = JsonConvert.SerializeObject(packet);
            // Convert the JSON string to bytes
            // byte[] data = Encoding.UTF8.GetBytes(json);
            if (ws != null && ws.IsAlive)
            {
                ws.Send(json);
            }
            else
            {
                Debug.LogWarning("WebSocket is not connected");
            }
        }

        // Static method to get the WebSocket client instance
        public static WebSocketClient GetInstance()
        {
            return instance;
        }
    }
}