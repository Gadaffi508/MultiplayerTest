using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public string LobbyCode { get; set; }

    public List<Player> player = new();

    public GameObject prefabPlayer;
    
    public override void OnStartServer()
    {
        Debug.Log("Sunucu başlatıldı (Mirror).");
    }

    public override void OnStopServer()
    {
        Debug.Log("Sunucu durduruldu (Mirror).");
    }

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Bir istemci bağlandı (Mirror): " + conn.connectionId);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Bir istemci bağlantı kesti (Mirror): " + conn.connectionId);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject gamePlayerInstance = Instantiate(prefabPlayer);
        Player playerInstance = gamePlayerInstance.GetComponent<Player>();
        
        playerInstance.connectionID = conn.connectionId;
        playerInstance.playerIdNumber = player.Count + 1;
        
        NetworkServer.AddPlayerForConnection(conn, playerInstance.gameObject);
    }

    public override void OnStartClient()
    {
        Debug.Log("İstemci başlatıldı (Mirror).");
    }

    public override void OnClientConnect()
    {
        Debug.Log("Sunucuya bağlanıldı (Mirror).");
    }

    public override void OnClientDisconnect()
    {
        Debug.Log("Sunucudan ayrıldı (Mirror).");
    }

    public override void OnStopClient()
    {
        Debug.Log("İstemci durduruldu (Mirror).");
    }
}