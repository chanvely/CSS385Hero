using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    public float speed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spawned eggs traverse towards its direction at a speed of 40 units/sec
        transform.position += transform.up * (speed * Time.smoothDeltaTime);

    }

    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(this.gameObject);
        }
    }
}
