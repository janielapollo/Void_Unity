/*Created by: Janiel Apollo S. Bodiongan*/
using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

    private GameObject ObjDestroyer;
    void Start () {
        ObjDestroyer = GameObject.FindGameObjectWithTag ("ObjDestroyer");
    }
    void Update () {

        if (transform.position.y < ObjDestroyer.transform.position.y) {
            gameObject.SetActive (false);

        }


    }
}
