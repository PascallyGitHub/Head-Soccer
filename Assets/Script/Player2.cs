using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(6, 0, 0);
    public Vector2 speed = new Vector2(10, 10);
    public float jump = 7;
    public float shootingPower = 500;

    public static Player2 S;
    public Rigidbody2D rigid;
    float inputX;
    float inputY;
    bool isGrounded;
    public bool wantsRematch;

    public void Start()
    {
        S = this;
        rigid = GetComponent<Rigidbody2D>();
        transform.position = startPosition;
    }

    void Update()
    {
        // reset inputs so that the player does not constantly move
        inputX = 0;
        inputY = 0;

        // get inputs for every axis. values between -1 and 1. 0 => button not pressed
        inputX = Input.GetAxis("Horizontal Player 2");
        inputY = Input.GetAxis("Vertical Player 2");

        if (!Gui.S.gameOver) // if game ends, player stops moving
        {
            // move horizontal
            Vector3 movement = new Vector3(speed.x * inputX, rigid.velocity.y, 0);
            movement *= Time.deltaTime;
            transform.Translate(movement);

            // WORKAROUND: jump if y < -1.7f (if it is very close to the ground)
            if (transform.position.y < -1.7f && inputY > 0 && isGrounded)
            {
                rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                isGrounded = false;
            }
        } 
        else
        {
            // stop inputs
            // inputX = 0;
            // inputY = 0;
            // freeze player
            // rigid.velocity = Vector2.zero;
            // rigid.angularVelocity = 0;
            // rigid.gravityScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) // on collision with the ball, add force to it
    {
        if (coll.gameObject.tag == "Ball")
        {
            coll.rigidbody.gravityScale = Ball.S.gravityScaleValue;
            coll.rigidbody.AddForce(new Vector2(-400, shootingPower)); // direction and strength of the shot
        }
        if (coll.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}