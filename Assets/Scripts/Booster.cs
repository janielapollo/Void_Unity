using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {



    private PlayerController player;
    private PlaySound sound;
    void Awake () {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
        sound = GameObject.Find ("SoundManager").GetComponent<PlaySound>();

    }
    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player") {
            player.PowerUps (1);
            sound.PlayBoost ();
            gameObject.SetActive (false);

        }
    }
}
