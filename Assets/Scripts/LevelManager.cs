using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
        public static LevelManager instance;
        Vector3 EnemySpawnVector;
        int xx = 0, yy= 0;
        private int i=1;
        public GameObject EnemyPrefab;

        
        private void Awake() {
            if (LevelManager.instance == null ) { instance = this;}
            else {
                Debug.Log("Destroyed Level Manager");
                Destroy(gameObject);
                }
        }



        public void gameOver(){
            /*
            UIManager _ui = GetComponent<UIManager>();
            if (_ui != null){
                _ui.ToggleDeathPanel();
                
            }
            */
        }

        private void FixedUpdate() {
            GameObject player = GameObject. Find ("Player"); 
            if (player != null){
                Transform playerTransform = player. transform;      // get player position
                Vector3 position = playerTransform.position;

                if ( Time.time > i){     //if position.x > i * 2
                    i+=2;
                    xx = Random.Range(-4, 4);
                    yy = Random.Range(-4, 4);
                    EnemySpawnVector = new Vector3 (xx, yy, 0f);
                    GameObject Enemy= Instantiate(EnemyPrefab, position + EnemySpawnVector, Quaternion.identity);
            }
        }
        }


}
