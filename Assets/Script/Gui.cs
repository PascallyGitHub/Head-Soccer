using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{
    public static Gui S;

    public Text rightScore;
    public Text leftScore;
    public GameObject goalText;
    public Text countdown;

    public bool gameOver;
    public int player1Goals;
    public int player2Goals;
    public int secondsUntilEndOfMatch;

    void Start()
    {
        S = this;
        gameOver = false;
        player1Goals = 0;
        player2Goals = 0;
        goalText.SetActive(false);

        InvokeRepeating("decreaseCountdown", 0f, 1f); // start decreasing countdown every second
    }

    void Update()
    {
        rightScore.text = player2Goals.ToString(); // update player2 goals
        leftScore.text = player1Goals.ToString(); // update player1 goals

        // RESET THE MATCH HERE !!!
        if (gameOver && Player1.S.wantsRematch)
        {
            secondsUntilEndOfMatch = 120;
            Start();
            Player1.S.Start();
            Player2.S.Start();
            Ball.S.Start();
        }
    }

    public void ScoreGoalText(String i)
    {
        StartCoroutine(ScoreGoalTextEnum(i)); // ???
    }

    IEnumerator ScoreGoalTextEnum(String i)
    {
        goalText.SetActive(true);
        goalText.GetComponent<Text>().text = i + " SCORED!";
        yield return new WaitForSeconds(2f); // display the "Player x goal!" sign for 1 second
        goalText.SetActive(false);
    }

    public void GoalTextShowResult(String i)
    {
        StartCoroutine(GoalTextShowResultEnum(i));
    }

    IEnumerator GoalTextShowResultEnum(String i)
    {
        goalText.SetActive(true);
        goalText.GetComponent<Text>().text = i;
        yield return new WaitForSeconds(4f);
        goalText.SetActive(false);
    }

    public void decreaseCountdown()
    {
        countdown.text = secondsUntilEndOfMatch.ToString();
        secondsUntilEndOfMatch--;

        if (secondsUntilEndOfMatch < 0)
        {
            // add some more code for when the game ends
            gameOver = true;

            if (player1Goals > player2Goals)
            {
                S.GoalTextShowResult("GERMANY WINS!");
            } 
            else if (player1Goals < player2Goals)
            {
                S.GoalTextShowResult("SCOTLAND WINS!");
            }
            else
            {
                S.GoalTextShowResult("DRAW!");
            }

            CancelInvoke("decreaseCountdown"); // stop repeating the process
        }
    }
}
