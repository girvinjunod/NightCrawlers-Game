using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;


public class EndlessScoreboardManager : MonoBehaviour
{
    private EndlessScoreData scoreData;

    void Awake()
    {
        var json = PlayerPrefs.GetString("EndlessScoreboard", "{}");
        scoreData = JsonUtility.FromJson<EndlessScoreData>(json);
    }
    public IEnumerable<EndlessScore> GetHighScores()
    {
        return scoreData.scores.OrderByDescending(x => x.time);
    }

    public void AddScore(EndlessScore score)
    {
        scoreData.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(scoreData);
        // Debug.Log(json);
        PlayerPrefs.SetString("EndlessScoreboard", json);
    }
}
