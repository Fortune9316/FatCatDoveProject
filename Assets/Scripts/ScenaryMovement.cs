using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryMovement : MonoBehaviour {
    Rigidbody2D rgb;
    float speed;
	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        speed = 15f;
	}
	
	// Update is called once per frame
	void Update () {
        ScenaryMove();
	}

    void ScenaryMove()
    {
        Vector2 dir= new Vector2(-1f, 0f);
        rgb.velocity = dir * speed;
    }
}
