using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDiscDirecction : MonoBehaviour
{
    private int playerRotationY;

    // player rotates from 0 to 180
    // and from -180 to 0
    // platform rotation disabled at 180 and 0
    private void ReversedDirection()
    {
        if (playerRotationY < 0 && playerRotationY > -180)
        {

        }
        else if(playerRotationY > 0 && playerRotationY < 180)
        {

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
        }
    }

    private void SetPlayerRotation(int anInt)
    {
        playerRotationY = anInt;
    }
}
