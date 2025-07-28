using System.Collections.Generic;

public static class LobbyManager
{
    public static Dictionary<string, List<string>> activeLobbies = new();

    public static void CreateLobby(string code)
    {
        if (!activeLobbies.ContainsKey(code))
            activeLobbies.Add(code, new List<string>());
    }

    public static void AddPlayer(string code, string playerName)
    {
        if (activeLobbies.ContainsKey(code))
            activeLobbies[code].Add(playerName);
    }

    public static List<string> GetPlayers(string code)
    {
        return activeLobbies.TryGetValue(code, out var players) ? players : null;
    }

    public static List<string> GetAllLobbyCodes()
    {
        return new List<string>(activeLobbies.Keys);
    }
}
