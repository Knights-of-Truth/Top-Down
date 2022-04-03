using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEnemy : Enemy
{
    private Vector2 velo;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        velo = new Vector2(Random.Range(-1,1)*speed,Random.Range(-1,1)*speed);
    }

    void Bounce(){
        rb.AddForce(velo);
    }
    // Update is called once per frame
    void Update()
    {
        if (Breserk){
            Bounce();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Wall"){
            Debug.Log(velo);
            velo = -1 * velo;
            Debug.Log(velo);
        }
    }
}
