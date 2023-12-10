using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    Rigidbody2D rigid;
    public Vector2 speed = new Vector2(10, 10);
    public float jump = 4;
    public float kickPower = 10;
    float inputX = 0;
    float inputY = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = 0;

        if (Input.GetKey(KeyCode.A)) // only if key A is pressed. Exclude arrow Left
        {
            inputX = Input.GetAxis("Horizontal");
        }

        if (Input.GetKey(KeyCode.D)) // only if key D is pressed. Exclude Arrow Right
        {
            inputX = Input.GetAxis("Horizontal");
        }

        Vector3 movement = new Vector3(speed.x * inputX, rigid.velocity.y, 0); // 1 multiplied with speed

        inputY = Input.GetAxis("Vertical");

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    void OnCollisionEnter2D(Collision2D coll) // on collision with the ball, add force to it
    {
        if (coll.gameObject.tag == "Ball")
        {
            coll.rigidbody.AddForce(new Vector2(400, 100));
        }
    }

    void OnCollisionStay2D(Collision2D coll) // if grounded an W or ArrowUp is pressed, jump
    {
        if (coll.gameObject.tag == "Ground" && (inputY > 0))
        {
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
}
