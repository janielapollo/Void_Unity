using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public AudioSource tap,over,boost,glass,blue;
    void Awake () {
        DontDestroyOnLoad (this.gameObject);
    }
    public void PlayTap () {
        tap.Play ();
    }
    public void PlayGameOver () {
        over.Play ();
    }
    public void PlayBoost () {
        boost.Play ();
    }
    public void BreakBrick () {
        glass.Play ();
    }
    public void PlayBlue () {
        blue.Play ();
    }
    public void StopBoost () {
        if (boost.isPlaying) {
            boost.Stop ();
        }    
    }

}
