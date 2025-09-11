using System;
using Photon.Pun;
using Photon.Realtime;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class SteamLobbyManager : MonoBehaviour
{
    public static SteamLobbyManager Instance;
    
    [Header("UI Reference")]
    public Text debugText;

    [Header("Room Reference")]
    public static string lobbyName = "LobbyName";
    public int maxPlayers = 4;

    public CSteamID currentRoomID;
    
    private Callback<LobbyCreated_t> onLobbyCreated;
    private Callback<LobbyEnter_t> onLobbyEnter;
    private Callback<GameLobbyJoinRequested_t> onLobbyJoinRequested;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        onLobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
        onLobbyEnter = Callback<LobbyEnter_t>.Create(OnLobbyEnter);
        onLobbyJoinRequested = Callback<GameLobbyJoinRequested_t>.Create(OnLobbyJoinRequested);
    }

    public void CreateRoom()
    {
        if (!IsNetworkReady()) return;

        string roomNane = SteamFriends.GetPersonaName();

        RoomOptions roomOptions = new RoomOptions
        {
            IsVisible = true,
            MaxPlayers = maxPlayers
        };

        PhotonNetwork.CreateRoom(roomNane, roomOptions);
        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, maxPlayers);
        
        debugText.text = "Create Room name : " + roomNane;
    }

    public void JoinRoom(string lobbyUserName, CSteamID lobbyID)
    {
        if (!IsNetworkReady()) return;

        PhotonNetwork.JoinRoom(lobbyUserName);
        
        SteamMatchmaking.JoinLobby(lobbyID);
        
        debugText.text = "Join Room name : " + lobbyUserName;
    }

    public void LeaveRoom(CSteamID lobbyID)
    {
        if (!PhotonNetwork.InRoom) return;
        
        PhotonNetwork.LeaveRoom();
        
        SteamMatchmaking.LeaveLobby(lobbyID);
        
        Debug.Log("Leave Room");
    }

    private void OnLobbyCreated(LobbyCreated_t result)
    {
        if(result.m_eResult != EResult.k_EResultOK) return;

        currentRoomID = new CSteamID(result.m_ulSteamIDLobby);
        
        SteamMatchmaking.SetLobbyData(currentRoomID, lobbyName,SteamFriends.GetPersonaName());
        
        SteamMatchmaking.SetLobbyMemberLimit(currentRoomID,maxPlayers);
    }

    private void OnLobbyEnter(LobbyEnter_t result)
    {
        if(PhotonNetwork.InRoom) return;
        
        CSteamID enteredLobbyID = new CSteamID(result.m_ulSteamIDLobby);

        if (enteredLobbyID == currentRoomID && SteamMatchmaking.GetLobbyOwner(enteredLobbyID) != SteamUser.GetSteamID())
        {
            string _lobbyName = SteamMatchmaking.GetLobbyData(enteredLobbyID, lobbyName);
            
            debugText.text = "Join Room name : " + _lobbyName;
        }

        SteamMatchmaking.RequestLobbyList();
    }

    private void OnLobbyJoinRequested(GameLobbyJoinRequested_t result)
    {
        currentRoomID = result.m_steamIDLobby;

        SteamMatchmaking.JoinLobby(result.m_steamIDLobby);
    }

    bool IsNetworkReady()
    {
        if (CustomNetworkManager.Instance == null) return false;
        if (CustomNetworkManager.Instance.OnInitalized == false) return false;
        if (PhotonNetwork.IsConnectedAndReady == false) return false;

        return true;
    }
}