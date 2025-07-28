using Mirror;
using TMPro;
using UnityEngine;

public class GameManagerStart : MonoBehaviour
{
    [SerializeField] TMP_InputField lobbyField;
    
    [SerializeField] TextMeshProUGUI warningText;

    [SerializeField] [Scene] string sceneName = string.Empty;
    
    public string serverIp = "localhost";

    LobbyCreater _creater;

    private GameManager manager;
    
    private void Start()
    {
        manager = new GameManager();
    }
    
    public void StartServer()
    {
        NetworkManager.singleton.StartHost();
        
        _creater = new LobbyCreater();
        
        string code = _creater.GenerateLobbyCode();
        
        NetworkManager.singleton.lobbyCode = code;
        
        LobbyManager.CreateLobby(code);
        
        Debug.Log("Lobi oluşturuldu: " + code);
    }
    
    public void StartClient()
    {
        if (lobbyField.text.Length == 0)
        {
            warningText.text = "Lobby ID'si girilmelidir.";
            return;
        }
        
        NetworkManager.singleton.lobbyCode = lobbyField.text;
        
        NetworkManager.singleton.networkAddress = serverIp;
        
        NetworkManager.singleton.StartClient();
    }
}
