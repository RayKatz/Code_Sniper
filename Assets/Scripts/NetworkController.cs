using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class NetworkController : MonoBehaviour {

    public int port;
    public Text ipText;

    NetworkClient lClient;

    void Start()
    {
        Object.DontDestroyOnLoad(gameObject);
        Application.runInBackground = true;
    }

    public void SetupServer()
    {
        NetworkServer.Listen(port);
    }

    public void SetupCLient()
    {
        lClient = new NetworkClient();
        lClient.RegisterHandler(MsgType.Connect, OnConnected);
        lClient.Connect(ipText.text, port);
    }

    public void SetupLocalClient()
    {
        lClient = ClientScene.ConnectLocalServer();
        lClient.RegisterHandler(MsgType.Connect, OnConnected);
    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to Server");
    }
}
