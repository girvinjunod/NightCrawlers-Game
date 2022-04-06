using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveScoreboardManager : MonoBehaviour
{
    private WaveScoreData scoreData;

    void Awake()
    {
        var json = PlayerPrefs.GetString("WaveScoreboard", "{}");
        scoreData = JsonUtility.FromJson<WaveScoreData>(json);
        // Debug.Log(StateHolder.GameMode);
        if (StateHolder.GameMode == "WaveMode")
        {
            // StateHolder.playerName = "Cupuuu";
            // StateHolder.playerScore = 27;
            // StateHolder.playerWave = 2;
            StateHolder.highScorePos = -1;
            if (scoreData.scores.Count == 0)
            {
                scoreData.scores.Insert(0, new WaveScore(StateHolder.playerName, StateHolder.playerScore, StateHolder.playerWave));
                StateHolder.highScorePos = 0;
            }
            else
            {
                bool inserted = false;
                for (int i = 0; i < scoreData.scores.Count; i++)
                {
                    // Debug.Log(scoreData.scores[i].playername + " - " + scoreData.scores[i].score);
                    if (scoreData.scores[i].score <= StateHolder.playerScore)
                    {
                        scoreData.scores.Insert(i, new WaveScore(StateHolder.playerName, StateHolder.playerScore, StateHolder.playerWave));
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
                    scoreData.scores.Add(new WaveScore(StateHolder.playerName, StateHolder.playerScore, StateHolder.playerWave));
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
