using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

    public string escena;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void Restart()
    {
        SceneManager.LoadScene(escena);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Restart();
    }
}
