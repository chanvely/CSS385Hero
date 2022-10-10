using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public EnemyManagerScript eManager;
    public int energy = 100; // for 4 times collsion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) {

        // Comes in contact with eggs
        // Loses 25% of current energy
        // Once energy gets to 0% --> destroy the enemy & spawn new one
        if (collision.gameObject.CompareTag("Egg")) {
            energy -= 25;
            
            // Color changes after collision
            Color losingColor = GetComponent<SpriteRenderer>().color;
            losingColor.a = energy * 0.008f;
            GetComponent<SpriteRenderer>().color = losingColor;
            
            if (energy <= 0) {
                // As soon as one enemy destroyed, new enemy will be created
                Destroy(this.gameObject);
                eManager.spawningNewEnemies();
                eManager.destroyEnemies();
            }
        }
        else if (collision.gameObject.CompareTag("Player")) {
            // As soon as one enemy destroyed, new enemy will be created
            eManager.spawningNewEnemies();
            Destroy(this.gameObject);
            eManager.destroyEnemies();
        }
        else {
            // As soon as one enemy destroyed, new enemy will be created
            eManager.spawningNewEnemies();
            Destroy(this.gameObject);
        }
    
    }
}
