using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusEnemy : Enemy
{
    
    public GameObject bullet;
    private float timestamp = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Breserk = false;
    }

    void shootBeams(){
        if (timestamp <= Time.time) {
            timestamp = Time.time + 0.2f;
            Instantiate(bullet,transform.position + new Vector3(1,0,0),Quaternion.AngleAxis(-90,Vector3.forward));
            Instantiate(bullet,transform.position + new Vector3(0,1,0),Quaternion.AngleAxis(0,Vector3.forward));
            Instantiate(bullet,transform.position + new Vector3(-1,0,0),Quaternion.AngleAxis(90,Vector3.forward));
            Instantiate(bullet,transform.position + new Vector3(0,-1,0),Quaternion.AngleAxis(180,Vector3.forward));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Breserk){
            shootBeams();
        }
    }
}
