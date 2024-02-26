using UnityEngine;
using WebSocketSharp;

public class WebSocketClient : MonoBehaviour
{
    private static WebSocketClient instance;

    private WebSocket ws;

    // URL of the WebSocket server
    [SerializeField]
    private string serverUrl = "ws://127.0.0.1:8080/Echo";


    private void Awake()
    {
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
        // Connect to the WebSocket server
        Connect();
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

    private void OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log("Received message: " + e.Data);
    }

    private void OnError(object sender, ErrorEventArgs e)
    {
        Debug.LogError("WebSocket error: " + e.Message);
    }

    private void OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("Curr url" + serverUrl);
        Debug.Log("WebSocket closed with code: " + e.Code + ", reason: " + e.Reason);
    }

    // Example method to send a message to the server
    public void SendMessageToServer(string message)
    {
        if (ws != null && ws.IsAlive)
        {
            ws.Send(message);
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
