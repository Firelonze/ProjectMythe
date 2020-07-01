using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformRotation : PlayerSpeedTracker
{
    public PlayerMovement playerMovement;
    public PlayerFollow playerFollow;

    private bool allowRotate = false;
    private bool clockWise = true;

    //Rotation increases or decreases depending on where the player is running and what direction (0-180,180-360) they're running in.
    // x and z coordinates checking based on the turning object in the game
    // human vision = 90 to 100 degrees so 135 -50 & 135 + 50 = y Rotation limitations
    private void Update()
    {
        if (allowRotate == true)
        {
            RotatePlatform();
            if (clockWise == false)
            {
                transform.Rotate(0, movesSpeed /= 3, 0);
            }
            else if (clockWise == true)
            {
                transform.Rotate(0, (movesSpeed /= 3) * -1, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "groundChecker")
        {
            allowRotate = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "groundChecker")
        {
            allowRotate = false;
        }
    }

    private void RotatePlatform()
    {
        
        clockWise = Vector3.Dot(playerFollow.transform.position - playerMovement.gameObject.transform.position, playerMovement.gameObject.transform.right) > 0;
    }
}