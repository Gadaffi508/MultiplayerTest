using System;
using Mirror;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panelObj, panelText;

    [SerializeField] private TextMeshProUGUI lobbyPortText;

    private void Start()
    {
        Setup();

        ushort port = NetworkManager.singleton.GetComponent<TelepathyTransport>().Port;
        
        lobbyPortText.text = "Lobby Port : " + port;
    }

    public void LeaveGame()
    {
        NetworkManager.singleton.StopClient();
    }

    void Setup()
    {
        bool isServerOnly = NetworkServer.active && !NetworkClient.active;
        panelObj.SetActive(isServerOnly);
        panelText.SetActive(isServerOnly);
    }
}