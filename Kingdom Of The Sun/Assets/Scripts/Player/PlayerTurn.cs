using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private float speedH = 2.0f;

    private float yaw = 0.0f;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yaw, 0.0f);
    }
}
