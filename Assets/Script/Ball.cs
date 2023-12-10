using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "GoalRight") // TODO: add code for when the ball hits the right goal
        {
            Gui.S.player1Goals++;
            Gui.S.ScoreGoalText(1);
        }
        if (coll.gameObject.tag == "GoalLeft") // TODO: add code for when the ball hits the left goal
        {
            Gui.S.player2Goals++;
            Gui.S.ScoreGoalText(2);
        }
    }

}
