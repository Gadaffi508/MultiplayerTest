using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class CustomGameManager : NetworkBehaviour
{
    [SyncVar] private double gameStartTime;

    public Text customTimeText,standartTimeText = null;

    public float gameDuration = 60f;

    public override void OnStartServer()
    {
        gameStartTime = NetworkTime.time;
    }

    public float GetElapsedTime()
    {
        return (float)(NetworkTime.time - gameStartTime);
    }

    public float GetRemainingTime()
    {
        return Mathf.Max(0f, gameDuration - GetElapsedTime());
    }

    public void StartHost()
    {
        StandartGameManager.singleton.StartHost();
    }
    
    public void StartClient()
    {
        StandartGameManager.singleton.StartClient();
    }

    void Update()
    {
        customTimeText.text = $"Kalan (Custom)Süre: {GetRemainingTime():F2}";
        standartTimeText.text = StandartGameManager.singleton.time;
    }
}
