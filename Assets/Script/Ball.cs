using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball S;
    Rigidbody2D rigid;
    public Vector3 startPosition = new Vector3(0f, 3f, 0f);
    public float gravityScaleValue = 1.5f;

    public void Start()
    {
        S = this;
        rigid = GetComponent<Rigidbody2D>();
        transform.position = startPosition;
    }

    void Update()
    {
        if (Gui.S.gameOver) // freeze the ball when game ends
        {
            rigid.velocity = Vector2.zero;
            rigid.angularVelocity = 0f;
            rigid.gravityScale = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "GoalRight")
        {
            Gui.S.player1Goals++;
            Gui.S.ScoreGoalText("GERMANY");
            ResetEntities();
        }
        if (coll.gameObject.tag == "GoalLeft")
        {
            Gui.S.player2Goals++;
            Gui.S.ScoreGoalText("SCOTLAND");
            ResetEntities();
        }
    }

    void ResetEntities()
    {
        // reset ball
        rigid.velocity = Vector2.zero;
        rigid.angularVelocity = 0f;
        rigid.gravityScale = 0f;
        transform.position = startPosition;

        // reset player1
        Player1.S.Start();

        // reset player2
        Player2.S.Start();
    }
}
