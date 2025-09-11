using Mirror;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ServerAdminPanel : MonoBehaviour
{
    public TextMeshProUGUI clientListText;

    private Dictionary<int, string> connectedClients = new();

    void OnEnable()
    {
        NetworkServer.OnConnectedEvent += OnClientConnected;
        NetworkServer.OnDisconnectedEvent += OnClientDisconnected;
    }

    void OnDisable()
    {
        NetworkServer.OnConnectedEvent -= OnClientConnected;
        NetworkServer.OnDisconnectedEvent -= OnClientDisconnected;
    }

    void OnClientConnected(NetworkConnectionToClient conn)
    {
        connectedClients[conn.connectionId] = conn.address;
        UpdateUI();
    }

    void OnClientDisconnected(NetworkConnectionToClient conn)
    {
        connectedClients.Remove(conn.connectionId);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (clientListText == null) return;

        clientListText.text = $"🧍 Players: {connectedClients.Count}\n";
        foreach (var pair in connectedClients)
        {
            clientListText.text += $"• ID: {pair.Key} | IP: {pair.Value}\n";
        }
    }
}