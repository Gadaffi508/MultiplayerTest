using System;
using Mirror;
using UnityEngine;

public class CustomMirrorCustomNetworkManager : NetworkManager
{
    public static event Action Initialized;

    public override void OnStartHost()
    {
        base.OnStartHost();
        Initialized?.Invoke();
    }
}
