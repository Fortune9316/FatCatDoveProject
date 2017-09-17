using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        offset = new Vector3(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y, player.transform.position.z - transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position - offset;
        SmoothCamera();
    }

    void LerpCamera()
    {
        Vector3 desiredPos = player.position + offset;
        transform.position = player.transform.position - offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothPos;
        transform.LookAt(player);
    }

    void SmoothCamera()
    {
        Vector3 point = Camera.main.WorldToViewportPoint(player.position);
        Vector3 delta = player.position - Camera.main.ViewportToWorldPoint(new Vector3(0.3f, 0.4f, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothSpeed);
    }

}
