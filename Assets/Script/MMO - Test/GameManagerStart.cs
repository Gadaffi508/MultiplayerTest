using Mirror;
using TMPro;
using UnityEngine;

public class GameManagerStart : MonoBehaviour
{
    [SerializeField] TMP_InputField lobbyField;
    
    [SerializeField] TextMeshProUGUI warningText;

    [SerializeField] [Scene] string sceneName = string.Empty;
    
    public string serverIp = "localhost";
    
    CustomNetworkManager _manager;

    public CustomNetworkManager Manager
    {
        get
        {
            if (_manager != null) return _manager;
            return _manager = NetworkManager.singleton as CustomNetworkManager;
        }
    }

    LobbyCreater _creater;

    private GameManager manager;
    
    private void Start()
    {
        manager = new GameManager();
    }
    
    public void StartServer()
    {
        Manager.StartHost();
        
        _creater = new LobbyCreater();

        Manager.LobbyCode = _creater.GenerateLobbyCode();

        ChangeScene();
    }
    
    public void StartClient()
    {
        if (lobbyField.text.Length == 0)
        {
            warningText.text = "Lobby ID'si girilmelidir.";
            return;
        }
        
        Manager.StartClient();
        
        Manager.LobbyCode = lobbyField.text;

        ChangeScene();
    }

    void ChangeScene()
    {
        manager.ChangeScene(sceneName);
    }
}
