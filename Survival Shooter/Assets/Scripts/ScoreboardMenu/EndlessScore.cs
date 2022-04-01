using System;

[Serializable]
public class EndlessScore
{
    public string playername;
    public string time;

    public EndlessScore(string playername, string time)
    {
        this.playername = playername;
        this.time = time;
    }
}