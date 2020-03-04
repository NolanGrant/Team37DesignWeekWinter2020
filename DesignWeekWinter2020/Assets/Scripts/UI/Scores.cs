using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scores : MonoBehaviour
{
    public int player1Score;
    public int player2Score;
    public Text highscoreLbl;
    public Text player1ScoreLbl;
    public Text player2ScoreLbl;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("1stScore") > player1Score && PlayerPrefs.GetInt("1stScore") > player2Score)
        {
            highscoreLbl.text = PlayerPrefs.GetInt("1stScore").ToString();
        } else
        {
            if (player1Score > player2Score)
            {
                highscoreLbl.text = player1Score.ToString();
            } else
            {
                highscoreLbl.text = player2Score.ToString();
            }
        }
        player1ScoreLbl.text = player1Score.ToString();
        player2ScoreLbl.text = player2Score.ToString();
    }

    public void OnEndGame()
    {
        if(HighScoreManager.hsManager.CheckHighScore(player1Score))
        {
            // bring up player 1 initials screen
        }

        if (HighScoreManager.hsManager.CheckHighScore(player2Score))
        {
            // bring up player 2 initials screen
        }
    }
}
