using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;


public class WaveScoreboardManager : MonoBehaviour
{
    private WaveScoreData scoreData;

    void Awake()
    {
        var json = PlayerPrefs.GetString("WaveScoreboard", "{}");
        scoreData = JsonUtility.FromJson<WaveScoreData>(json);
    }
    public IEnumerable<WaveScore> GetHighScores()
    {
        return scoreData.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(WaveScore score)
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
        PlayerPrefs.SetString("WaveScoreboard", json);
    }
}
