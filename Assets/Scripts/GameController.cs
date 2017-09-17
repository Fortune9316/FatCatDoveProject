using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public string lvlToLoad;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void levelToLoad(string newLvl)
    {
        if(newLvl != null)
            lvlToLoad = newLvl;
    }
    public void ButStart()
    {
        //fade.GetComponent<Renderer>().material = originalColor;

        StartCoroutine("Change");
    }

    IEnumerator Change()
    {
        //yield return new WaitForSeconds(1);
        float fadeTime = gameObject.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(lvlToLoad);
    }
}
