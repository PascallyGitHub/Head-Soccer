using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);

    // Update is called once per frame
    void Update()
    {
        float inputX = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            inputX = Input.GetAxis("Horizontal");
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            inputX = Input.GetAxis("Horizontal");
        }

        Vector3 movement = new Vector3(speed.x * inputX, 0, 0); // 1 multiplied with speed

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
}
