using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float MinSpeed,MaxSpeed,BoostSpeed;
    public float currentSpeed;
    public float distance = 2f;
    private Vector2 objPos;
    
    private Transform playerPos;
    private Rigidbody2D rb;

    private GameManager gm;
    private bool isAlive;

    //Timer for power ups
    public float SetTimer;
    //Booster PowerUp

    private float BoostTimer;
    public bool Boost;
    private ParticleSystem effect1;

    //Shield
    private GameObject blue;
    public bool Shield;
    private float ShieldTimer;
    public int count;

    //Script
    private PlaySound sounds;
    void Awake () {  
        rb = gameObject.GetComponent<Rigidbody2D> ();
        gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
        effect1 = GameObject.FindGameObjectWithTag("SaiyanEffect").GetComponent<ParticleSystem> ();
        blue = GameObject.Find ("Shield");
        
    }
    void Start () {
        playerPos = gameObject.transform;
        isAlive = true;
        gm.isDead (isAlive);
        blue.SetActive (false);
        Shield = false;
        effect1.Stop ();
    }
    void OnMouseDrag() {
        Vector2 pos = new Vector2 (Input.mousePosition.x * distance, transform.position.y) ;
        objPos = Camera.main.ScreenToWorldPoint (pos);
        playerPos.transform.position = new Vector2 (Mathf.Clamp (objPos.x, -2.77f, 2.77f), transform.position.y);
    }
    void FixedUpdate () {
        
        if (!Boost) {
            currentSpeed = Random.Range (MinSpeed, MaxSpeed);
            rb.velocity = new Vector2 (rb.velocity.x, currentSpeed*currentSpeed * Time.deltaTime);
        }
        else if (Boost) {
            BoostTimer -= Time.deltaTime;
                currentSpeed = (MaxSpeed * MaxSpeed) * Time.deltaTime;
                effect1.Play ();
                rb.velocity = new Vector2 (rb.velocity.x, currentSpeed);
                if (BoostTimer < 0) {
                    effect1.Stop ();
                    Boost = false;
                    BoostTimer = SetTimer;
                }
          
        }
        if (Shield) {
            blue.SetActive (true);
            ShieldTimer -= Time.deltaTime;
            if (ShieldTimer < 0 || !Shield) {
                blue.SetActive (false);
                Shield = false;
            }
        }
        
    }
    public void PowerUps (int check) {
        switch (check) {
            case 1:
                Boost = true;
                BoostTimer = 7;
                break;
            case 2:
                Shield = true;
                count = 2;
                ShieldTimer = 20;
                break;
            case 3:
                ShieldTimer = 0;
                break;
            default:
                Debug.LogError ("Incorrect Value.");
                break;
        }
    }
}



