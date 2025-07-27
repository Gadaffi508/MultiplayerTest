using System;
using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public string _name = "Empty";

    [SyncVar]
    public int _playerIdNumber;

    public string Name => string.IsNullOrEmpty(_name) ? "Empty" : _name;

    public override void OnStartServer()
    {
        // Bu sadece serverda çalışır → burada oyuncuya isim verebilirsin
        _name = "Yusuf " + netId;
        _playerIdNumber = (int)netId;
        Debug.Log("Player serverda oluşturuldu: " + _name);
    }

    public override void OnStartLocalPlayer()
    {
        Debug.Log("Bu benim yerel oyuncum: " + _name);
    }

    private void Start()
    {
        // Artık burası gerekmez ama bilgi istersen
        Debug.Log("Start çalıştı: " + _name);
    }
}