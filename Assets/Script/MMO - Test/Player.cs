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
        NetworkManager.singleton.allPlayers.Add(this.gameObject);
        
        _name = "Player " + netId;
        _playerIdNumber = (int)netId;
        
        DontDestroyOnLoad(this);
    }
}