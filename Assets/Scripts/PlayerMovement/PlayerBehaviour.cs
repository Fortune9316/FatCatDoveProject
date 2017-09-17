using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    //UI
    public Text texto;

    //Components
    Rigidbody2D rgb;
    public GameObject point;

    //Other variables
    float speed;
    float Vspeed;
    bool move;
    Vector3 target;

    // Use this for initialization
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        //PlayerMove2();

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
        Vector2 mov = new Vector2(0, Vspeed);

        if (active)
        {
            //Ajusta a las coordenadas al tamaño de la pantalla 
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Estas trabajando en 2d
            target.z = transform.position.z;

            //Si el valor de move es falso, se convierte a verdadero
            if (move == false)
            {
                move = true;
            }

            //Crea multiples instancias de puntos (se usa tambien para obtener las coordenadas de donde estamos tocando en la pantalla)
            Instantiate(point, target, Quaternion.identity);

            //Si la altura de donde tocamos es mayor que la altura del personaje, la velocidad
            if (target.y > transform.position.y)
            {
                Vspeed = -1;
            }
            else
            {
                Vspeed = 1;
            }
            mov = new Vector2(0, Vspeed);
        }


        if (move == true)
        {
            rgb.velocity = mov * speed;
            move = false;
        }

    }

    void PlayerMove2()
    {
        bool active = Input.GetMouseButtonDown(0);
        Vector2 mov = new Vector2(0, Vspeed);

        if (active)
        {
            //Ajusta a las coordenadas al tamaño de la pantalla 
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Estas trabajando en 2d
            target.z = transform.position.z;

            //Si el valor de move es falso, se convierte a verdadero
            if (move == false)
            {
                move = true;
            }

            //Crea multiples instancias de puntos (se usa tambien para obtener las coordenadas de donde estamos tocando en la pantalla)
            Instantiate(point, target, Quaternion.identity);

            //Si la altura de donde tocamos es mayor que la altura del personaje, la velocidad
            if (target.y > transform.position.y)
            {
                Vspeed = -1;
            }
            else
            {
                Vspeed = 1;
            }
            mov = new Vector2(0, Vspeed);
        }


        if (move == true)
        {
            rgb.velocity = mov * speed;
        }
    }


}