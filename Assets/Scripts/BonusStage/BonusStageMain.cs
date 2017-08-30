using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStageMain : MonoBehaviour {

    #region States
    enum BonusStates
    {
        BORN,
        PLAYING,
        GAMEOVER
    }
    #endregion
    #region public variables

    public static BonusStageMain instance;

    [Header("Notes")]
    public List<GameObject> notes;

    public Transform spawnPoint;

    [HideInInspector]
    public float minX;
    [HideInInspector]
    public float maxX;
    [HideInInspector]
    public float minY;
    [HideInInspector]
    public float maxY;

    #endregion

    #region private variables

    private BonusStates bonusStates;

    private float timeElapsed;
    private float timeToSpawn;

    #endregion

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {

        //Initialize variables
        bonusStates = BonusStates.PLAYING;
        timeElapsed = 0f;
        timeToSpawn = 0f;
        setBoundsXY();
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        

        switch (bonusStates)
        {
            case BonusStates.BORN:
                break;
            case BonusStates.PLAYING:
                timeToSpawn += Time.deltaTime;

                if(timeToSpawn >= Random.Range(1,3))
                {
                    ActiveRandomNote();
                    timeToSpawn = 0f;
                }

                for (int i = 0; i < notes.Count; i++)
                {
                    if(notes[i].activeInHierarchy)
                    {
                        notes[i].GetComponent<NoteController>().UpdateNote();
                    }
                }
                break;
            case BonusStates.GAMEOVER:
                break;
            default:
                break;
        }
    }

    private void ActiveRandomNote()
    {
        for (int i = 0; i < notes.Count; i++)
        {
            if (!notes[i].activeInHierarchy)
            {                
                notes[i].GetComponent<NoteController>().spawnPoint = spawnPoint.position;
                Vector3 dirAux = new Vector3(Random.Range(minX, maxX), Random.Range(2, maxY), 0f);
                dirAux = Vector3.Normalize(dirAux);
                notes[i].GetComponent<NoteController>().dir = dirAux - spawnPoint.position;
                notes[i].SetActive(true);
                break;
            }
        }
    }

    void setBoundsXY()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(
            Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
        maxY = bounds.y - 0.5f;
        minY = -bounds.y + 0.5f;
    }
}
