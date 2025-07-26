using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public string LobbyCode { get; set; }

    public List<Player> players = new();
    
    public Player currentPlayerPrefab;
    
    public override void OnStartServer()
    {
        Debug.Log("Sunucu başlatıldı (Mirror).");
        base.OnStartServer();
    }

    public override void OnStopServer()
    {
        Debug.Log("Sunucu durduruldu (Mirror).");
        base.OnStopServer();
    }

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Bir istemci bağlandı (Mirror): " + conn.connectionId);
        base.OnServerConnect(conn);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        Debug.Log("Bir istemci bağlantı kesti (Mirror): " + conn.connectionId);
    }
    
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Player playerInstance = Instantiate(currentPlayerPrefab); // playerPrefab atanmalı

        playerInstance._playerIdNumber = players.Count + 1;
        playerInstance.connectionID = conn.connectionId;

        players.Add(playerInstance);

        NetworkServer.AddPlayerForConnection(conn, playerInstance.gameObject);
        Debug.Log($"Oyuncu eklendi: {playerInstance.name}, ID: {playerInstance.playerIdNumber}");
    }

    public override void OnStartClient()
    {
        Debug.Log("İstemci başlatıldı (Mirror).");
        base.OnStartClient();
    }

    public override void OnClientConnect()
    {
        Debug.Log("Sunucuya bağlanıldı (Mirror).");
        base.OnClientConnect();
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