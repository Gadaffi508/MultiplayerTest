using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class GameManager
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
