using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    private float speedV = 2.0f;
    
    private float pitch = 0.0f;

    private Vector3 euler;

    private void LateUpdate()
    {
        pitch -= speedV * Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -145f, -70f);

        transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, pitch);
        euler = new Vector3(pitch - 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }
}
