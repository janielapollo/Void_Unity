/* Created by: Janiel Apollo S. Bodiongan*/
using UnityEngine;
using System.Collections;

public class PlatformSpawn : MonoBehaviour {

    public Transform ObjectSpawner;
    public Transform Parent;
    public float distanceBetween;
    private float[] ObjectHeight;
    public ObjectPooler [] theObjectPools;
    
    private int ObjectSelector;
    private bool relative = false;

    

    void Start () {
        ObjectHeight = new float[theObjectPools.Length];
    }

    void Update () {
        if (transform.position.y < ObjectSpawner.position.y) {
                ObjectSelector = Random.Range (0, theObjectPools.Length);
                transform.position = new Vector2 ( 0, transform.position.y + (ObjectHeight [ObjectSelector] / 2) + distanceBetween);

                GameObject newObject = theObjectPools [ObjectSelector].GetPooledObject ();
                newObject.transform.SetParent (Parent.transform, relative);
                newObject.transform.position = transform.position;
                newObject.transform.rotation = transform.rotation;
                newObject.SetActive (true);
            
            
        }

    }
}
