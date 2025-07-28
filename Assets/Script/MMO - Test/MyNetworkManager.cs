using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void Awake()
    {
        base.Awake();
        autoCreatePlayer = false;
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        if (conn.identity != null)
        {
            Debug.LogError("Zaten bir oyuncu var.");
            return;
        }

        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}