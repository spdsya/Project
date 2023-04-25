using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed = 10.0f;

    //public GameObject player;
    public Transform TargetTransform;
    Vector3 refVelocity;
    public float smoothSpeed = 1.0f;

    void Update()
    {
        if(TargetTransform != null) {
            transform.position = Vector3.SmoothDamp(transform.position, TargetTransform.position, ref refVelocity, smoothSpeed) + new Vector3(0,0,-1);
            
        }
        /*Vector3 dir = transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
        }*/
    }
}