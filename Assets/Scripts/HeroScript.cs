using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroScript : MonoBehaviour
{
    // For control mode
    public float speed = 20f;
    public float rotateSpeed = 45f;
    private bool control = false;

    // For spawning eggs
    public GameObject eggProjectile;
    private bool spawning = true;

    // For application status of HERO control mode
    public TextMeshProUGUI textHero;
    public string controlMode;

    // For application status of # of EGGs
    public TextMeshProUGUI textEgg;
    public int numOfEggs = 0;

    // For application status of touching ENEMY
    public TextMeshProUGUI textHeroTouching;
    public int touchingEnemy = 0;
 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        // control mode with 'm' key between mouse/keyboard control
        // changes the mode(status)
        if (Input.GetKeyDown("m")) {
            
            // false -> true or true -> false
            control = !control;
        }

        // Keyboard control
        if (control) {
            // Up/Down (w/s) keys gradually increases/decreases 
            // hero's speed moving towards its Transfor.up direction
            speed += Input.GetAxis("Vertical");
            transform.position += transform.up * (speed * Time.smoothDeltaTime);
            
            // application status
            controlMode = "Keyboard";
            textHero.text = "HERO: Drive(" + controlMode + ")";
        }
        // Mouse control: hero's position follow the mouse
        else { 
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;
            transform.position = p;

            // application status
            controlMode = "Mouse";
            textHero.text = "HERO: Drive(" + controlMode + ") ";
        }

        // Left/Right (a/d) keys: turn the hero towards left/right at a rate of 45-degrees/sec.
        transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (rotateSpeed * Time.smoothDeltaTime));

        // Spawning eggs with space bar
        if (Input.GetKey(KeyCode.Space)) {

            if (spawning) {
                StartCoroutine(shootEggs());
            }
        }

        if (Input.GetKeyDown("q")) {

            Application.Quit();
        }
    }

    private IEnumerator shootEggs() {
        spawning = false; // stop till waiting 2 seconds after shooting
        GameObject spawnedEgg = Instantiate(eggProjectile);
        spawnedEgg.transform.position = transform.position;
        spawnedEgg.transform.up = transform.up;
        
        spawnedEgg.GetComponent<EggScript>().decreaseEggs = this;
        numOfEggs++;
        textEgg.text = "EGG: OnScreen(" + numOfEggs + ") ";

        yield return new WaitForSeconds(.2f);
        spawning = true; // ready to shoot next one
    }

    public void decreaseNumEggs() {
        numOfEggs--;
        textEgg.text = "EGG: OnScreen(" + numOfEggs + ") ";
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Enemy")) {
            touchingEnemy++;
            textHeroTouching.text = "TouchedEnemy(" + touchingEnemy + ") ";
        }
    }
}