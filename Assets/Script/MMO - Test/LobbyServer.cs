using Mirror;
using UnityEngine;

public class LobbyServer : NetworkBehaviour
{
    public override void OnStartServer()
    {
        NetworkServer.RegisterHandler<EmptyMessage>(OnRequestLobbyData);
    }

    private void OnRequestLobbyData(NetworkConnection conn, EmptyMessage msg)
    {
        var data = new LobbyDataMessage
        {
            lobbyCodes = LobbyManager.GetAllLobbyCodes()
        };

        conn.Send(data);
    }
}
