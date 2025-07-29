using UnityEngine;
using Mirror;
using TMPro;

public class ServerManager : MonoBehaviour
{
    public TMP_InputField portField;
    
    

    private void Start()
    {
        portField.text = NetworkManager.singleton.GetComponent<TelepathyTransport>().Port.ToString();
    }

    public void StartHost()
    {
        ushort port;
        if (ushort.TryParse(portField.text, out port))
        {
            NetworkManager.singleton.GetComponent<TelepathyTransport>().Port = port;
        }
        else
        {
            NetworkManager.singleton.GetComponent<TelepathyTransport>().Port = 7777;
        }
        
        NetworkManager.singleton.StartServer();
        Debug.Log("Server başlatıldı.");
    }
}
