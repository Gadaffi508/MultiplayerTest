using System;
using UnityEngine;
using Mirror;
using TMPro;

public class ConnectClient : MonoBehaviour
{
    public TMP_InputField ipField;

    public void ConnectToServer()
    {
        ushort port;
        
        if (ushort.TryParse(ipField.text, out port))
        {
            NetworkManager.singleton.GetComponent<TelepathyTransport>().Port = port;
        }
        else
        {
            NetworkManager.singleton.GetComponent<TelepathyTransport>().Port = 7777;
        }
        
        
        NetworkManager.singleton.StartClient();
        Debug.Log("Client bağlanmaya çalışıyor...");
    }
}