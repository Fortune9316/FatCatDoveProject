using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadespeed = 0.8f;

    private int drawDepth = -1000;
    public float alpha;
    private int fadeDir = -1;
    // Use this for initialization

    void OnGUI()
    {
        alpha += fadeDir * fadespeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        //GUI.color = new Color(0, 0, 0, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); 
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return fadespeed;
    }

    //void OnLevelWasLoaded()
    //{
    //    BeginFade(-1);
    //}
}
