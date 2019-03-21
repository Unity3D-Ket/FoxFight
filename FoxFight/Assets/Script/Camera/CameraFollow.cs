using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerCam;
        
    public float minX, MaxX;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempcam = transform.position;
        tempcam.x = playerCam.position.x;
        //tempcam.y = playerCam.position.y;

        if (tempcam.x < minX) {
            tempcam.x = minX;
        }

        if (tempcam.x > MaxX) {
            tempcam.x = MaxX;
        }

        transform.position = tempcam;

    }//update

}//camerafollow
