using System.Net.Sockets;
using UnityEngine;
using Mirror;
using System.Net;
using TMPro;

public class ServerManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField portField;
    
    public TMP_InputField ipField;
    
    private TelepathyTransport transport;

    private void Awake()
    {
        transport = NetworkManager.singleton.GetComponent<TelepathyTransport>();

        string _port = transport.Port.ToString();

        portField.text = _port;

        ipField.text = _port;
    }

    public void StartHost()
    {
        if (!ushort.TryParse(portField.text, out ushort port))
            port = 7777;

        if (!IsPortFree(port))
        {
            Debug.LogWarning($"❌ Port {port} already in use. Server start aborted.");
            return;
        }

        transport.Port = port;
        NetworkManager.singleton.StartServer();

        if (!NetworkServer.active)
        {
            Debug.LogError("❌ Server failed to start even after StartServer.");
        }
        else
        {
            Debug.Log($"✅ Server started on port {port}");
        }
    }
    
    public void ConnectToServer()
    {
        if (ushort.TryParse(ipField.text, out ushort port))
            transport.Port = port;
        else
            transport.Port = 7777;

        NetworkManager.singleton.StartClient();
    }
    
    private bool IsPortFree(int port)
    {
        TcpListener listener = null;

        try
        {
            listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();

            System.Threading.Thread.Sleep(50); 

            return true;
        }
        catch (SocketException)
        {
            return false;
        }
        finally
        {
            listener?.Stop();
        }
    }


    
}
