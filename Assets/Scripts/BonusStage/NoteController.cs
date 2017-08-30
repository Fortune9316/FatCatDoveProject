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
        speed = 0.5f;
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
                print("moving");
                if (Input.GetButtonDown("Fire1"))
                {
                    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    //if(Physics.Raycast(ray, out raycasthit))
                    //{
                    //    if (raycasthit.collider.gameObject.tag == "note")
                    //    {
                    //        noteStates = NoteStates.DIE;
                    //    }
                    //}

                    print("click");

                    if(Vector3.Distance(transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition)) <= 0.2f)
                    {
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
