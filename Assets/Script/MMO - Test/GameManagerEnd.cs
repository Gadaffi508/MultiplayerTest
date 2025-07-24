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
        EditorGUIUtility.systemCopyBuffer = lobbyIDText.text;
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
