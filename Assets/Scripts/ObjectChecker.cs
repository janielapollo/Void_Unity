using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChecker : MonoBehaviour {

    public Transform [] childrens;
    void Awake () {
        childrens = gameObject.GetComponentsInChildren<Transform> ();
    }
    void OnEnable () {
        foreach (Transform meh in childrens) {
            if (meh.gameObject.activeInHierarchy == false) {
                meh.gameObject.SetActive (true);
            }

        }
    }
}
