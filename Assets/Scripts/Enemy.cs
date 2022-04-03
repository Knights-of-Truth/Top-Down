using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour{
    [Header ("Movement")]
    public float speed = 3f;
    
    [Header ("Attack")]
    [SerializeField] protected float attackDamage = 10f;
    [SerializeField] protected float attackSpeed = 1f;
    private float canAttack;

    [Header ("Parent")]
    public bool Breserk;
    public Rigidbody2D rb;
    public CircleCollider2D cc;
    public CircleCollider2D cc2;

    [Header ("Health")]
    [SerializeField] private float maxHealth;
    private float Health;

    void Start(){
        Health = maxHealth;
        Breserk = false;
    }
    public void TakeDamage(float dmg){
        Health -= dmg;
        Debug.Log("Enemy Health: "+ Health);

        if(Health <= 0){
            Destroy(gameObject);
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
