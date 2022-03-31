using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public Rigidbody2D rb;
    public GameObject bullet;
    private Vector2 dest;
    private int speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setdest(Vector2 x){
        dest = x;
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.rotation * Vector2.up * speed;
        rb.freezeRotation = true;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }
    }
}
