using Mirror;
using UnityEngine;

public class StandartGameManager : NetworkManager
{
    public float gameDuration = 60f;
    
    public static StandartGameManager singleton;

    public string time;
    
    private double gameStartTime;

    public override void Awake()
    {
        singleton = this;
    }

    public override void OnStartServer()
    {
        gameStartTime = NetworkTime.time;
    }
    
    public float GetElapsedTime()
    {
        return (float)(NetworkTime.time - gameStartTime);
    }

    void Update()
    {
        time = $"Kalan (Standart)Süre: {GetRemainingTime():F2}";
    }

    public float GetRemainingTime()
    {
        return Mathf.Max(0f, gameDuration - GetElapsedTime());
    }
}
