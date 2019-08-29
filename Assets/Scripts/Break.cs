using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {

    private GameObject player;
    private GameObject boomObj;
    private ParticleSystem boom;
    //Scripts
    private GameManager gm;
    private PlayerController play;
    private PlaySound sound;
    void Start () {

        player = GameObject.FindGameObjectWithTag ("Player");
        boomObj = GameObject.Find ("Break_Effect");
        gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
        sound = GameObject.Find ("SoundManager").GetComponent<PlaySound> ();
        play = player.GetComponent<PlayerController> ();
        boom = boomObj.GetComponent<ParticleSystem> ();
    }
    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject == player) {
            if (play.Boost == true) {
                boomObj.transform.position = player.transform.position;
                boom.Play ();
                sound.BreakBrick ();
                gameObject.SetActive (false);
            } else if (play.Shield == true) {
                play.count -= 1;
                sound.PlayBlue ();
                if (play.count == 0) {
                    sound.BreakBrick ();
                    play.PowerUps (3);
                }
                
            }else {
                boomObj.transform.position = player.transform.position;
                boom.Play ();
                gm.isDead (false);
                sound.PlayGameOver ();
                player.SetActive (false);
            }
            
        }
    
    }
}
