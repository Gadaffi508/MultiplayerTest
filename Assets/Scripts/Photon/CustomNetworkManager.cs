using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Steamworks;

public class CustomNetworkManager : MonoBehaviourPunCallbacks
{
    #region Singleton
    
    private static CustomNetworkManager _instance;
    public static CustomNetworkManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("NetworkManager instance is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    #endregion

    public bool OnInitalized { get; private set; }
    
    public List<PhotonPlayer> GamePlayer { get; } = new();
    
    void Start()
    {
        if (SteamManager.Initialized)
        {
            Debug.Log(SteamFriends.GetPersonaName());
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        OnInitalized = true;
    }
}
