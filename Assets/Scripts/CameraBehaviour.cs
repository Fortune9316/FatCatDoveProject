using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;
    
    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = new Vector3(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y, player.transform.position.z - transform.position.z );
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position - offset;
    }
}
