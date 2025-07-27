using Mirror;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManagerEnd : NetworkBehaviour
{
    public TextMeshProUGUI lobbyIDText;

    GameManager _manager;

    private void Start()
    {
        _manager = new GameManager();

        this.gameObject.AddComponent<NetworkIdentity>();

        lobbyIDText.text = _manager.Manager.LobbyCode;
    }

    public void Copy()
    {
#if UNITY_EDITOR
        EditorGUIUtility.systemCopyBuffer = lobbyIDText.text;
#else
            GUIUtility.systemCopyBuffer = lobbyIDText.text;
#endif
    }

    public void Stop()
    {
        if (isServer)
        {
            _manager.Manager.StopServer();
        }
        else
        {
            _manager.Manager.StopClient();
        }

        _manager.ChangeScene("TestScene");
    }
}