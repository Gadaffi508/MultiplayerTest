using System.Collections.Generic;
using System.Linq;
using Mirror;

public class LobbyCreater
{
    private Dictionary<string, NetworkConnectionToClient> lobbies = new();
    
    public string GenerateLobbyCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new System.Random();
        string code;
        do
        {
            code = new string(
                new char[6].Select(c => chars[random.Next(chars.Length)]).ToArray()
            );
        } while (lobbies.ContainsKey(code));

        return code;
    }
}
