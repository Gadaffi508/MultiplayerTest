using Mirror;
using UnityEngine;

public class Item : NetworkBehaviour
{
    [ServerCallback]
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NetworkServer.Destroy(gameObject);
            Debug.Log("Destroy " + this.gameObject.name);
        }
    }
}