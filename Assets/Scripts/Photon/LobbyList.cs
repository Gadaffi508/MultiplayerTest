using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;
using WebSocketSharp;

public class LobbyList : MonoBehaviour
{
    public static LobbyList Instance;

    public GameObject roomPrefab;
    public Transform listContent;

    private Callback<LobbyMatchList_t> onLobbyMatchList;
    private List<CSteamID> availableRooms = new();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        onLobbyMatchList = Callback<LobbyMatchList_t>.Create(OnLobbyMatchList);
        RequestRoomList();
    }

    public void RequestRoomList()
    {
        availableRooms.Clear();

        foreach (Transform child in listContent)
        {
            Destroy(child.gameObject);
        }

        SteamMatchmaking.RequestLobbyList();
    }

    void OnLobbyMatchList(LobbyMatchList_t result)
    {
        if (result.m_nLobbiesMatching == 0 && CustomNetworkManager.Instance == null)
            return;

        foreach (Transform child in listContent)
        {
            if(child.gameObject != null)
                Destroy(child.gameObject);
        }
        
        for (int i = 0; i < result.m_nLobbiesMatching; i++)
        {
            CSteamID lobbyID = SteamMatchmaking.GetLobbyByIndex(i);
            int playerCount = SteamMatchmaking.GetNumLobbyMembers(lobbyID);

            if (playerCount > 0)
            {
                availableRooms.Add(lobbyID);
                CreateRoomListItem(lobbyID);
            }
        }
    }

    void CreateRoomListItem(CSteamID lobbyID)
    {
        if (roomPrefab == null || listContent == null) return;

        GameObject roomItem = Instantiate(roomPrefab, listContent);
        Room room = roomItem.GetComponent<Room>();

        if (room == null) return;

        string lobbyName = SteamMatchmaking.GetLobbyData(lobbyID, "LobbyName");

        int playerCount = SteamMatchmaking.GetNumLobbyMembers(lobbyID);
        int maxPlayers = SteamMatchmaking.GetLobbyMemberLimit(lobbyID);

        if (lobbyName.IsNullOrEmpty())
            room.SetLobbyInfo("Null", playerCount, lobbyID, "Null");
        else
            room.SetLobbyInfo(lobbyName, playerCount, lobbyID, lobbyName);
    }
}