using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {
    public Text texto;

    float speed;

    float Vspeed;
    Rigidbody2D rgb;

    bool move;
    public GameObject point;
    Vector3 target;
    
    
    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        texto = FindObjectOfType<Text>();
        speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
        //FollowPoint();        
        PlayerMove();
        texto.text = "" + Input.mousePosition.x + " - " + Input.mousePosition.y + "\n";
    }

    void FollowPoint()
    {
        //0-> left button, 1->right button, 2-> middle click
        bool active = Input.GetMouseButtonDown(0);
        if (active)
        {
            //Hacer que los clicks solo funcionen dentro de la pantalla (dentro del enfoque de la camara)
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Es 2d, por lo que el eje z no es necesario
            target.z = transform.position.z;

            if (move == false)
            {
                move = true;
            }

            //Crea instancias de un punto (indicador de donde
            Instantiate(point, target, Quaternion.identity);
        }

        if (move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }



    }

    void PlayerMove()
    {
        bool active = Input.GetMouseButtonDown(0);
        if (active)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            if (move == false)
            {
                move = true;
            }

            Instantiate(point, target, Quaternion.identity);
            if(target.y > transform.position.y)
            {
                Vspeed = -1;
            }
            else
            {
                Vspeed = 1;
            }
        }

        if(move == true)
        {
            rgb.velocity = new Vector2(1 * speed, Vspeed * speed);
        }

    }
}


