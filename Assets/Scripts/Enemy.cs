using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour{
    [Header ("Movement")]
    public float speed = 3f;
    
    [Header ("Attack")]
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    [Header ("Health")]
    [SerializeField] private float maxHealth;
    private float Health;
    private Transform target;

    void Start(){
        Health = maxHealth;
    }
    public void TakeDamage(float dmg){
        Health -= dmg;
        Debug.Log("Enemy Health: "+ Health);

        if(Health <= 0){
            Destroy(gameObject);
        }
    }

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

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else{
                canAttack += Time.deltaTime;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other){
        if (other.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else{
                canAttack += Time.deltaTime;
            }
        }
    }
}
