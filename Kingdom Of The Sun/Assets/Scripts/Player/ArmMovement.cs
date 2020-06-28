using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    private float speedV = 2.0f;

    private float pitch = 0.0f;

    private Vector3 euler;

    private void LateUpdate()
    {
        pitch -= speedV * Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -15f, 60f);

        transform.eulerAngles = new Vector3(-pitch, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        euler = new Vector3(pitch, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }
}