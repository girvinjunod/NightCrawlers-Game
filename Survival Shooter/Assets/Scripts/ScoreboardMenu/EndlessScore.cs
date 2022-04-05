using System;

[Serializable]
public class EndlessScore
{
    public string playername;
    public int time;

    public EndlessScore(string playername, int time)
    {
        this.playername = playername;
        this.time = time;
    }
}