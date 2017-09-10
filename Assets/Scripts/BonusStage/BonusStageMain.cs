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

    [Header("Doves")]
    public List<GameObject> doves;

    [Header("Star Particles")]
    public List<ParticleSystem> particlesStars;

    public Transform spawnPoint;

    [HideInInspector]
    public float minX;
    [HideInInspector]
    public float maxX;
    [HideInInspector]
    public float minY;
    [HideInInspector]
    public float maxY;
    //[HideInInspector]
    public float streakVelocity;

    #endregion

    #region private variables

    private BonusStates bonusStates;

    private AudioSource audioSource;

    private float timeElapsed;
    private float timeToSpawn;
    private float counter;
    

    #endregion

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {

        //Initialize variables
        audioSource = GetComponent<AudioSource>();
        bonusStates = BonusStates.PLAYING;
        counter = 0f;
        streakVelocity = 0f;
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
                PitchMusic();
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

                foreach (GameObject dove in doves)
                {
                    dove.GetComponent<DoveController>().UpdateDove();
                }
                break;
            case BonusStates.GAMEOVER:
                break;
            default:
                break;
        }
    }

    private void PitchMusic()
    {
        counter += Time.deltaTime;
        if (streakVelocity > 0f)
            streakVelocity -= 0.01f;
        if (streakVelocity > 0f)
        {
            if (counter >= 0.3f && audioSource.pitch < 1)
            {
                audioSource.pitch += 0.1f;
                counter = 0f;
            }
        }
        else if (streakVelocity <= 0f)
        {
            if (counter >= 0.3f && audioSource.pitch > 0)
            {
                audioSource.pitch -= 0.1f;
                counter = 0f;
            }
        }
        if (audioSource.pitch <= 0f)
        {
            audioSource.pitch = 0f;
        }
    }

    private void ActiveRandomNote()
    {
        for (int i = 0; i < notes.Count; i++)
        {
            if (!notes[i].activeInHierarchy)
            {                
                notes[i].GetComponent<NoteController>().spawnPoint = doves[Random.Range(0,doves.Count)].transform.position;
                Vector3 dirAux = new Vector3(Random.Range(minX, maxX), Random.Range(2, maxY), 0f);
                dirAux = Vector3.Normalize(dirAux);
                notes[i].GetComponent<NoteController>().dir = dirAux - spawnPoint.position;
                notes[i].SetActive(true);
                break;
            }
        }
    }

    public void ActiveParticle(Vector3 spawnPoint)
    {
        for (int i = 0; i < particlesStars.Count; i++)
        {
            if (!particlesStars[i].isEmitting)
            {
                particlesStars[i].gameObject.SetActive(true);
                particlesStars[i].transform.position = new Vector3(spawnPoint.x,spawnPoint.y,particlesStars[i].transform.position.z);
                particlesStars[i].Play();
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
