using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlatformRotation : PlayerSpeedTracker
{
    private bool playerXisLess = false;
    private bool playerZisLess = false;
    private bool allowRotate = false;
    private bool clockWise = true;

    //Rotation increases or decreases depending on where the player is running and what direction (0-180,180-360) they're running in.
    // x and z coordinates checking based on the turning object in the game
    // human vision = 90 to 100 degrees so 135 -50 & 135 + 50 = y Rotation limitations
    private void Update()
    {
        if (playerPosition != player.transform.position)
        {
            playerPosition = player.transform.position;
        }
        if (playerRotation != player.transform.rotation)
        {
            playerRotation = player.transform.rotation;
            if (playerRotation.y < -180)
            {
                Mathf.Abs(playerRotation.y);
            }
            if (playerRotation.y > 180)
            {
                playerRotation.y -= 360;
            }
        }
        if (allowRotate == true)
        {
            RotatePlatform();
            if (clockWise == true)
            {
                transform.Rotate(0, movesSpeed /= 3, 0);
            }
            else if(clockWise == false)
            {
                transform.Rotate(0, (movesSpeed /= 3) *1, 0);
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
        if (playerPosition.x < this.transform.position.x)
        {
            playerXisLess = true;
        }
        else if (playerPosition.x > this.transform.position.x)
        {
            playerXisLess = false;
        }
        if (playerPosition.z < this.transform.position.z)
        {
            playerZisLess = true;
        }
        else if (playerPosition.z > this.transform.position.z)
        {
            playerZisLess = false;
        }
        switch (playerXisLess)
        {
            //left bottom corner
            case (true):
                switch (playerZisLess) { 
                    case (true):
                        Debug.Log("Case1");
                        if (playerRotation.y < -35 && playerRotation.y > 65)
                        {
                            clockWise = true;
                        }
                        else if (playerRotation.y < (-125) && playerRotation.y > (-25))
                        {
                            clockWise = false;
                        }
                    break;
                    case (false):
                        //Debug.Log("Case2");
                        if (playerRotation.y < 155 && playerRotation.y > 55)
                        {
                            clockWise = true;
                        }
                        else if (playerRotation.y < 35 && playerRotation.y > -115)
                        {
                            clockWise = false;
                        }
                        break;
                }
                break;
            //right bottom corner
            case (false):
                switch (playerZisLess)
                {
                    case (true):
                        //Debug.Log("Case3");
                        if (playerRotation.y < -35 && playerRotation.y > -135)
                        {
                            clockWise = true;
                        }
                        else if (playerRotation.y < (-65) && playerRotation.y > (35))
                        {
                            clockWise = false;
                        }
                        break;
                    case(false):
                        //Debug.Log("Case4");
                        if (playerRotation.y < 115 && playerRotation.y > 15)
                        {
                            clockWise = true;
                        }
                        else if (playerRotation.y < (-125) && playerRotation.y > (-25))
                        {
                            clockWise = false;
                        }
                    break;
                }
                break;
        }
    }
}
