using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class GameManager
{
    CustomNetworkManager _manager;

    public CustomNetworkManager Manager
    {
        get
        {
            if (_manager != null) return _manager;
            return _manager = NetworkManager.singleton as CustomNetworkManager;
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
