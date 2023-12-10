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

    public int player1Goals;
    public int player2Goals;

    void Start()
    {
        S = this;
        player1Goals = 0;
        player2Goals = 0;
        goalText.SetActive(false);
    }

    void Update()
    {
        rightScore.text = player2Goals.ToString(); // update player2 goals
        leftScore.text = player1Goals.ToString(); // update player1 goals
    }

    public void ScoreGoalText(int i)
    {
        StartCoroutine(ScoreGoalTextEnum(i)); // ???
    }

    IEnumerator ScoreGoalTextEnum(int i)
    {
        goalText.SetActive(true);
        goalText.GetComponent<Text>().text = "PLAYER " + i + " SCORED!";
        yield return new WaitForSeconds(2f); // display the "Player x goal!" sign for 1 second
        goalText.SetActive(false);
    }
}
