using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveScoreUI : MonoBehaviour
{
    public WaveRowUI rowUI;
    public WaveScoreboardManager scoreboardManager;
    // Start is called before the first frame update
    void Start()
    {

        // scoreboardManager.AddScore(new Score("Player1", 100, 1));
        // scoreboardManager.AddScore(new Score("Player2", 200, 2));
        var scores = scoreboardManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<WaveRowUI>();
            row.rank.text = (i + 1).ToString();
            row.playername.text = scores[i].playername;
            row.wave.text = scores[i].wave.ToString();
            row.score.text = scores[i].score.ToString();
        }
    }

}
