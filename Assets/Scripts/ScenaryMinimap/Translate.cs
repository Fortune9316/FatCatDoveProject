using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour {

    Transform myG;
    PlayerBehaviour player;
    Finish finish;
    public Transform miniFinish;
    private float distance;
    private float total;
    private float porcent;

    private float miniDistance;
    private float miniTotal;
    private float miniPorcent;
    private float newPos;
    private float iniPos;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerBehaviour>();
        finish = FindObjectOfType<Finish>();
        myG = GetComponent<Transform>();
        total = Mathf.Abs(player.transform.position.x - finish.transform.position.x);
        iniPos = myG.position.x;
        miniTotal = Mathf.Abs(iniPos - miniFinish.position.x);
	}
	
	// Update is called once per frame
	void Update () {
        distance = Mathf.Abs(player.transform.position.x - finish.transform.position.x);
        miniDistance = Mathf.Abs(myG.position.x - miniFinish.position.x);

        porcent = 1 - distance / total;

        miniPorcent = porcent;

        miniDistance = miniTotal*(1-miniPorcent);

        //miniDistance = miniFinish.position.x - myG.position.x;

        newPos = Mathf.Abs(miniDistance - miniFinish.position.x);

        if(Time.timeScale == 1 && iniPos != newPos)
            myG.position = new Vector3(newPos, myG.position.y, myG.position.z);
	}
}
