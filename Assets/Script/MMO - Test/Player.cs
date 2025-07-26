using System;
using Mirror;

public class Player : NetworkBehaviour
{
    public string Name
    {
        get
        {
            if (_name == null)
            {
                return "Empty";
            }
            else
            {
                return _name;
            }
        }
    }

    private string _name = null;

    public int connectionID
    {
        set { }
    }

    public int playerIdNumber
    {
        get { return _playerIdNumber; }
        private set { }
    }

    public int _playerIdNumber;

    public override void OnStartClient()
    {
        base.OnStartClient();
    }

    public override void OnStartAuthority()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _name = "Yusuf " + netId;
    }
}