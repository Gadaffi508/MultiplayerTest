using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public string LobbyCode { get; set; }
    
    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("Sunucu başlatıldı (Mirror).");
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        Debug.Log("Sunucu durduruldu (Mirror).");
    }

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);
        Debug.Log("Bir istemci bağlandı (Mirror): " + conn.connectionId);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
        Debug.Log("Bir istemci bağlantı kesti (Mirror): " + conn.connectionId);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        Debug.Log("Yeni oyuncu eklendi (Mirror): " + conn.connectionId);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        Debug.Log("İstemci başlatıldı (Mirror).");
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("Sunucuya bağlanıldı (Mirror).");
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();
        Debug.Log("Sunucudan ayrıldı (Mirror).");
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        Debug.Log("İstemci durduruldu (Mirror).");
    }
}