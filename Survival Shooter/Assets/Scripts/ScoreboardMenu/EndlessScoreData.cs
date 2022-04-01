using System;
using System.Collections.Generic;

[Serializable]
public class EndlessScoreData
{
    public List<EndlessScore> scores;

    public EndlessScoreData()
    {
        scores = new List<EndlessScore>();
    }
}