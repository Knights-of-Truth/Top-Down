using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] private float movespeed = 10f;
    [SerializeField] Transform hand;
    int var1, var2;
    float px, py, i;     //for the circle movement if uncommented

    private void Start() {
        var1 = 1; var2 = 1;
        i = 0;
        
        //InvokeRepeating("force", 2f, 1.5f);
        //InvokeRepeating("force2", 2.8f, 1.5f);
    }

    
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

    //force and force 2 to the trash
    void force(){            
        rb.AddForce(new Vector2(10*var1, 0));
        var1++;
        rb.velocity = new Vector2(10, 0);
    }
    void force2(){
        rb.AddForce(new Vector2(-10*var2, 0));
        rb.velocity = new Vector2(-15, 0);
        //rb.AddTorque(50f);
        var2++;
    }
}
