using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class LobbyClient : MonoBehaviour
{
    public LobbyListUI ui;

    void Start()
    {
        NetworkClient.RegisterHandler<LobbyDataMessage>(OnLobbyDataReceived);
    }

    public void RequestLobbyList()
    {
        NetworkClient.Send(new EmptyMessage());
    }

    void OnLobbyDataReceived(LobbyDataMessage msg)
    {
        ui.UpdateLobbyList(msg.lobbyCodes);
    }
}