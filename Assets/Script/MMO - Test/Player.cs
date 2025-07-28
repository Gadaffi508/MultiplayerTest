using System;
using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public string _name = "Empty";

    [SyncVar]
    public int _playerIdNumber;

    public string Name => string.IsNullOrEmpty(_name) ? "Empty" : _name;

    public override void OnStartServer()
    {
        
    }

    public override void OnStartLocalPlayer()
    {
        
    }

    private void Start()
    {
        if (isLocalPlayer)
        {
            _name = "Player " + netId;
            string code = NetworkManager.singleton.lobbyCode;
            LobbyManager.AddPlayer(code, _name);
            Debug.Log("Lobiye katıldı: " + _name);
        }

        NetworkManager.singleton.allPlayers.Add(this.gameObject);
        DontDestroyOnLoad(this);
    }
}