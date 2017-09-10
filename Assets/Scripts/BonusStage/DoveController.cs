using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoveController : MonoBehaviour {

    enum DoveStates
    {
        DANCE
    }

    #region Public variables
    #endregion

    #region Private variables
    private float flipTimer;
    private DoveStates doveStates;
    #endregion


    // Use this for initialization
    void Start () {
        doveStates = DoveStates.DANCE;
        flipTimer = 0f;
	}
	
	// Update is called once per frame
	public void UpdateDove () {
        switch (doveStates)
        {
            case DoveStates.DANCE:
                flipTimer += Time.deltaTime;
                if(flipTimer>=1f)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                    flipTimer = 0f;
                }
                break;
            default:
                break;
        }
    }
}
