using System;

[Serializable]
public class WaveScore
{
    public string playername;
    public float score;

    public int wave;

    public WaveScore(string playername, float score, int wave)
    {
        this.playername = playername;
        this.score = score;
        this.wave = wave;
    }
}