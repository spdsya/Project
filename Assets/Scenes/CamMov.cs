using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMov : MonoBehaviour
{
    public Camera Target;               // Ä«¸Þ¶ó°¡ µû¶ó´Ù´Ò Å¸°Ù
    public float cameraSpeed = 5.0f;

    // Update is called once per frame
    private void Update()
    {
        Vector3 dir = Target.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        this.transform.Translate(moveVector);
    }
}
