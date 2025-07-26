using Mirror;
using TMPro;
using UnityEngine;

public class GameManagerStart : MonoBehaviour
{
    [SerializeField] TMP_InputField lobbyField;
    
    [SerializeField] TextMeshProUGUI warningText;

    [SerializeField] [Scene] string sceneName = string.Empty;
    
    public string serverIp = "localhost";
    
    GameManager _manager;

    LobbyCreater _creater;
    
    private void Start()
    {
        _manager = new GameManager();
    }
    
    public void StartServer()
    {
        NetworkManager.singleton.StartHost();
        
        _creater = new LobbyCreater();

        _manager.Manager.LobbyCode = _creater.GenerateLobbyCode();

        ChangeScene();
    }
    
    public void StartClient()
    {
        if (lobbyField.text.Length == 0)
        {
            warningText.text = "Lobby ID'si girilmelidir.";
            return;
        }
        
        NetworkManager.singleton.networkAddress = serverIp;
        NetworkManager.singleton.StartClient();
        
        _manager.Manager.LobbyCode = lobbyField.text;

        ChangeScene();
    }

    void ChangeScene()
    {
        _manager.ChangeScene(sceneName);
    }
}
