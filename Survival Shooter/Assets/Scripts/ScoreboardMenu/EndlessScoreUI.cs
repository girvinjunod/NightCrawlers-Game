using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EndlessScoreUI : MonoBehaviour
{
    public EndlessRowUI rowUI;
    public EndlessScoreboardManager scoreboardManager;
    // Start is called before the first frame update
    void Start()
    {

        // scoreboardManager.AddScore(new EndlessScore("Player1", "00:01:01"));
        // scoreboardManager.AddScore(new EndlessScore("Player2", "00:00:30"));
        var scores = scoreboardManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<EndlessRowUI>();
            row.rank.text = (i + 1).ToString();
            row.playername.text = scores[i].playername;
            row.time.text = Utils.getTimeFromSeconds(scores[i].time);
            if (StateHolder.highScorePos == i)
            {
                row.rank.color = Color.yellow;
                row.playername.color = Color.yellow;
                row.time.color = Color.yellow;
            }
        }
    }

}
