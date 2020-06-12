using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmTurn : MonoBehaviour
{
    private float speedV = 2.0f;

    private float pitch = 0.0f;

    public Vector3 euler;
    public GameObject playerMovement;
    // Update is called once per frame
    void LateUpdate()
    {
        if (playerMovement.GetComponent<PlayerMovement>().curWeapon == 1)
        {
            pitch -= speedV * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, -60f, 90f);

            transform.eulerAngles = new Vector3(pitch, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        }
    }
}
