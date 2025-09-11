using System;
using Mirror;
using UnityEngine;

public class NetworkGameManager : MonoBehaviour
{
    public GameObject obj;
    private void Start()
    {
        CustomMirrorCustomNetworkManager.Initialized += OnInitialized;
    }

    private void OnDisable()
    {
        CustomMirrorCustomNetworkManager.Initialized -= OnInitialized;
    }

    void OnInitialized()
    {
        obj.SetActive(true);
    }
}