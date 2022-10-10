using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject enemy; // prefab

    // Start is called before the first frame update
    void Start()
    {
        // Always 10 enemies in the game screen
        for (int i = 0; i < 10; i++) {
            spawningNewEnemies();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // New enemy will be created at the same time one destroyed
    public void spawningNewEnemies() {
        
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.GetComponent<EnemyScript>().eManager = this;

        // Enemies are within 90% of the boundaries
        float maxY = (Camera.main.orthographicSize) * 0.9f;
        float maxX = (Camera.main.orthographicSize * Camera.main.aspect) * 0.9f;
        float enemyX = Random.Range(-maxX, maxX);
        float enemyY = Random.Range(-maxY, maxY);
        newEnemy.transform.position = new Vector3(enemyX, enemyY, 0f);
    }
}