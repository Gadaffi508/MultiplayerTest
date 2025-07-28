using Mirror;
using System.Collections.Generic;

public struct LobbyDataMessage : NetworkMessage
{
    public List<string> lobbyCodes;
}