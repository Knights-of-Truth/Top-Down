using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Movement : MonoBehaviour{
    public Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] private float movespeed = 10f;
    [SerializeField] Transform hand;
    //float px, py;     //for the circle movement if uncommented
    private void FixedUpdate() {
        RotateHand();
        MovementInput();
        rb.velocity = movement * movespeed;

            // px =  ((float)Math.Cos(i));          //to make it move in  circle    //just for testing
            // py =  ((float)Math.Sin(i));
            // i+= 0.1f;
            // rb.MovePosition(new Vector2(px, py));

    }
    void MovementInput (){
        float mx= Input.GetAxisRaw("Horizontal");
        float my= Input.GetAxisRaw("Vertical");
        movement = new Vector2 (mx, my).normalized;
    }
    void RotateHand(){
        float angle = Utility.AngleTowardsMouse(hand.position);
        hand.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
