using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public string playername;

    public PlayerData(string name)
    {
        playername = name;
    }
}