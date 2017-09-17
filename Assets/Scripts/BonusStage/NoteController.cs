using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour {

    #region States

    #region Public Variables

    public float speed;

    public Vector3 dir;
    public Vector3 spawnPoint;

    #endregion

    #region Private Variables

    private NoteStates noteStates;

    private RaycastHit raycasthit;

    #endregion

    enum NoteStates
    {
        BORN,
        MOVE,
        DIE,
    }

    #endregion
    // Use this for initialization
    void Start () {
        noteStates = NoteStates.BORN;
        speed = 2f;
	}
	
	// Update is called once per frame
	public void UpdateNote () {
        switch (noteStates)
        {
            case NoteStates.BORN:

                this.transform.position = spawnPoint;
                noteStates = NoteStates.MOVE;

                break;
            case NoteStates.MOVE:
                this.transform.position += dir * speed * Time.deltaTime;
                //print("moving");
                if (Input.GetButtonDown("Fire1"))
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.Scale(new Vector3(1, 1, 0));

                    if(Vector3.Distance(transform.position, mousePos) <= 0.5f)
                    {
                        if (BonusStageMain.instance.txtNum == 100)
                            
                        BonusStageMain.instance.ActiveParticle(transform.position);
                        if(BonusStageMain.instance.streakVelocity<1.5f)
                        BonusStageMain.instance.streakVelocity += 0.8f;
                        noteStates = NoteStates.DIE;
                    }
                }

                if(transform.position.x > BonusStageMain.instance.maxX || transform.position.x < BonusStageMain.instance.minX || transform.position.y> BonusStageMain.instance.maxY)
                {
                    noteStates = NoteStates.DIE;
                }

                break;
            case NoteStates.DIE:
                noteStates = NoteStates.BORN;
                this.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
