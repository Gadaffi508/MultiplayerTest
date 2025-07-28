using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyListUI : MonoBehaviour
{
    public GameObject lobbyButtonPrefab;
    public Transform contentParent;

    private void OnEnable()
    {
        RefreshLobbyList();
    }

    public void RefreshLobbyList()
    {
        // Öncekileri temizle
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        List<string> lobbies = LobbyManager.GetAllLobbyCodes();

        foreach (string code in lobbies)
        {
            GameObject obj = Instantiate(lobbyButtonPrefab, contentParent);
            obj.GetComponentInChildren<TMP_Text>().text = "Lobi: " + code;

            string capturedCode = code; // Lambda için capture
            //obj.GetComponent<Button>().onClick.AddListener(() => JoinLobby(capturedCode));
        }
    }

    public void UpdateLobbyList(List<string> codes)
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        foreach (string code in codes)
        {
            GameObject obj = Instantiate(lobbyButtonPrefab, contentParent);
            obj.GetComponentInChildren<TMP_Text>().text = "Lobi: " + code;

            string capturedCode = code;
            obj.GetComponent<Button>().onClick.AddListener(() => JoinLobby(capturedCode));
        }
    }


    public void JoinLobby(string code)
    {
        GameObject.Find("LobbyInputField").GetComponent<TMP_InputField>().text = code;
    }
}