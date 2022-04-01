using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider helathSlider;

    private void Start(){
        health = maxHealth;
        helathSlider.maxValue = maxHealth;
    }
    public void UpdateHealth(float mod){
        health += mod;
        Debug.Log("Player Health: " + health);
        if(health > maxHealth)
            health = maxHealth;
        else if (health <= 0f){
            health = 0f;
            Debug.Log("Player Respawn");
            helathSlider.value = health;
            PlayerDied();
         }
    }

    private void PlayerDied(){
        LevelManager.instance.gameOver();
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
    private void OnGUI(){
        float t= Time.deltaTime / 1f;
        helathSlider.value = Mathf.Lerp(helathSlider.value, health, t);
    }
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Enemy"){
            UpdateHealth(-10);
        }
    }
}
