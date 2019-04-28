using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesRotation : MonoBehaviour {

    public bool RotateRight, RotateLeft;
    private float currentspeed;
    void Start () {
        currentspeed = Random.Range (50f, 200f);
        
    }
	void Update () {
        if (RotateRight) {
            gameObject.transform.Rotate (transform.rotation.x, transform.rotation.y, currentspeed * Time.deltaTime);
        }
        else if (RotateLeft) {
            gameObject.transform.Rotate (transform.rotation.x, transform.rotation.y, -currentspeed * Time.deltaTime);
        }
        
	}
}
