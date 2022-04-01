using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour{
    public static LevelManager instance;
    private Vector3 EnemySpawnVector;
    private int enemyXPosition = 0, enemyYPosition= 0, i = 1;
    private float elapsed = 0f;
    public GameObject EnemyPrefab;
    private void Awake() {
        if (LevelManager.instance == null ){
            instance = this;
        }
        else{
            Debug.Log("Destroyed Level Manager");
            Destroy(gameObject);
        }
    }
    public void gameOver(){
        UIManager _ui = GetComponent<UIManager>();
        if (_ui != null){
            _ui.ToggleDeathPanel();
        }
    }
    private void FixedUpdate() {
        elapsed += Time.fixedDeltaTime;
        GameObject player = GameObject.Find("Player"); 
        if (player != null){
            Vector3 playerPosition = player.transform.position;
            //instantiate an enemy every 2 seconds.. its position is close to the player (range -4, 4)
            if ( elapsed > i){     //if playerPosition.x > i * 2
                i += 2;
                enemyXPosition = Random.Range(-4, 4);
                enemyYPosition = Random.Range(-4, 4);
                EnemySpawnVector = new Vector3 (enemyXPosition, enemyYPosition, 0f);
                // GameObject Enemy= Instantiate(EnemyPrefab, playerPosition + EnemySpawnVector, Quaternion.identity);
            }
        }
    }
}