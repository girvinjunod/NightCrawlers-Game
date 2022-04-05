using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EndlessScoreboardManager : MonoBehaviour
{
    private EndlessScoreData scoreData;

    void Awake()
    {
        var json = PlayerPrefs.GetString("EndlessScoreboard", "{}");
        scoreData = JsonUtility.FromJson<EndlessScoreData>(json);
        if (StateHolder.GameMode == "ZenMode")
        {
            // StateHolder.playerName = "Cupuuu";
            // StateHolder.playerTime = 4500;
            if (scoreData.scores.Count == 0)
            {
                scoreData.scores.Insert(0, new EndlessScore(StateHolder.playerName, StateHolder.playerTime));
                StateHolder.highScorePos = 0;
            }
            else
            {
                bool inserted = false;
                for (int i = 0; i < scoreData.scores.Count; i++)
                {
                    // Debug.Log(scoreData.scores[i].playername + " - " + scoreData.scores[i].time);
                    // Debug.Log(scoreData.scores[i].time);
                    // Debug.Log(StateHolder.playerTime);
                    if (scoreData.scores[i].time <= StateHolder.playerTime)
                    {
                        scoreData.scores.Insert(i, new EndlessScore(StateHolder.playerName, StateHolder.playerTime));
                        if (scoreData.scores.Count > 10)
                        {
                            scoreData.scores.RemoveAt(scoreData.scores.Count - 1);
                        }
                        StateHolder.highScorePos = i;
                        inserted = true;
                        break;
                    }
                }
                if (!inserted && scoreData.scores.Count < 10)
                {
                    scoreData.scores.Add(new EndlessScore(StateHolder.playerName, StateHolder.playerTime));
                    StateHolder.highScorePos = scoreData.scores.Count - 1;
                    inserted = true;
                }
                if (!inserted)
                {
                    StateHolder.highScorePos = -1;
                }
            }
            // StateHolder.GameMode = "Menu";
        }
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
