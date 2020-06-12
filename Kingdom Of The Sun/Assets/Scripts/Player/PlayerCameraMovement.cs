using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    private float speedV = 2.0f;
    
    private float pitch = 0.0f;

    public Vector3 euler;
    
    void Update()
    {
        pitch -= speedV * Input.GetAxis("Mouse Y");
        
        pitch = Mathf.Clamp(pitch, -60f, 90f);

        transform.eulerAngles = new Vector3(pitch, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        euler = new Vector3(pitch - 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }
}
