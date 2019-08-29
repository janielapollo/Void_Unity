using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMove : MonoBehaviour {

    float currentspeed;
    bool endPoint;
    void Awake () {
        currentspeed = Random.Range (2f, 5f);
    }
    void Update () {

        if (endPoint) {
            transform.position += Vector3.right * currentspeed * Time.deltaTime;

        }
        else {
            transform.position -= Vector3.right * currentspeed * Time.deltaTime;
        }
        if (transform.position.x >= 3.99f) {
            endPoint = false;
        }
        if (transform.position.x <= -3.99f) {
            endPoint = true;
        }
    }
}
