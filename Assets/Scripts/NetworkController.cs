using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System;

public class NetworkController : NetworkManager {

    //public Text ipText;

    bool playerJoined = false;

    public void SetupServer()
    {
        StartHost();
        ServerChangeScene("main");
    }

    public void SetupClient()
    {
       StartClient();
    }

    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        base.OnClientSceneChanged(conn);
        NetworkServer.SpawnObjects();
    }
}
