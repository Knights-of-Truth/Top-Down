using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : Enemy
{
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (target != null){
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }           
    }
    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Player"){
            target = other.transform;
        }
    }
    void OnTriggerExit2D (Collider2D other){
        if (other.gameObject.tag == "Player"){
            target = null;
        }
    }
}
