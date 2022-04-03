using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillClosestEnemy : Enemy
{
    private float rad;
    // Start is called before the first frame update
    void Start()
    {
        cc2.radius = 1;
        rad = cc2.radius;
    }

    void kill(){
        cc2.radius += 0.01f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Breserk){
            kill();
        }   
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("in");
        if (other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
            cc2.radius = rad;
            Breserk = false;
        }
        else if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-100);  
            cc2.radius = rad;
            Breserk = false;
        }
    }
}
