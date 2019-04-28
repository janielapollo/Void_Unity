using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object

    void LateUpdate () 
    {
        transform.position = (new Vector3( transform.position.x, player.transform.position.y, transform.position.z));
    }
}
