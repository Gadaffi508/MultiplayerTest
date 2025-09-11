using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public Text lobbyNameText;
    public Text playerCountText;
    public Button joinButton;

    public string lobbyName;

    private string photonRoomName;
    private CSteamID ID;

    public void SetLobbyInfo(string _lobbyName, int _playerCount,CSteamID _ID, string _photonRoomName)
    {
        lobbyName = _lobbyName;
        lobbyNameText.text = lobbyName;
        playerCountText.text = _playerCount.ToString();
        ID = _ID;
        photonRoomName = _photonRoomName;
    }

    public void JoinRoom()
    {
        SteamLobbyManager.Instance.JoinRoom(lobbyName,ID);
    }
}
