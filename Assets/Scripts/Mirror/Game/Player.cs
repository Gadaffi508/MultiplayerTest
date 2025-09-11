using System;
using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "LocalPlayer";
    }

    public override void OnStopClient()
    {
        NetworkManager.singleton.allPlayers.Remove(this.gameObject);
    }

    private void Start()
    {
        NetworkManager.singleton.allPlayers.Add(gameObject);
    }
}
