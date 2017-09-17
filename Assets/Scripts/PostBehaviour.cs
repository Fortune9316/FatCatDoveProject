using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PostBehaviour : MonoBehaviour {
    public string levelName;
    public float t = 1.5f;
    
    public GameObject txt;
    private void Start()
    {
        //text.IsActive();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Dying());
    }


    IEnumerator Dying()
    {
        txt.SetActive(true);

        while (t>=0)
        {
            t -= Time.deltaTime;
        }
        
        
        SceneManager.LoadScene(levelName);
        yield return null;
    }
}
