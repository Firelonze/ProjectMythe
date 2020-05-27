using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    private GameObject player;
    private Quaternion increasingRotation;
    private Vector3 playerPosition;
    private Quaternion playerRotation;
    private float increaseRotation;
    private float temporaryRotationY;
    private bool playerXisLess = false;
    private bool playerZisLess = false;

    //Rotation increases or decreases depending on where the player is running and what direction (0-180,180-360) they're running in.
    // x and z coordinates checking based on the turning object in game point
    // playerRotation.y is the rotation the player has while being controlled in game
    // 4 different direction options for the player {0 -> 180, -180 -> 0, 90 -> -90, -90 -> 90};
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "groundChecker")
        {
            RotatePlatform();
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
        else if (playerPosition.z < this.transform.position.z)
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
                        if (playerRotation.y < 90 && playerRotation.y > -90)
                        {
                            increaseRotation = 10;
                        }
                        if (playerRotation.y == 90 || playerRotation.y == -90)
                        {
                            increaseRotation = 0;
                        }
                        else
                        {
                            increaseRotation = -10;
                        }
                        break;
                    case (false):
                        if (playerRotation.y < 180 && playerRotation.y > 0)
                        {
                            increaseRotation = 10;
                        }
                        if (playerRotation.y == 180 || playerRotation.y == 0)
                        {
                            increaseRotation = 0;
                        }
                        else
                        {
                            increaseRotation = -10;
                        }
                        break;
                }
                    break;
            //right bottom corner
            case (false):
                switch (playerZisLess)
                {
                    case (true):
                        if (playerRotation.y < 0 && playerRotation.y > -180)
                        {
                            increaseRotation = 10;
                        }
                        if (playerRotation.y == -180 || playerRotation.y == 0)
                        {
                            increaseRotation = 0;
                        }
                        else
                        {
                            increaseRotation = -10;
                        }
                        break;
                    case(false):
                        if (playerRotation.y < -90 && playerRotation.y > 90)
                        {
                            increaseRotation = 10;
                        }
                        if (playerRotation.y == 90 || playerRotation.y == -90)
                        {
                            increaseRotation = 0;
                        }
                        else
                        {
                            increaseRotation = -10;
                        }
                        break;
                }
                break;
        }

        for (int i = 0; i < increaseRotation; i++)
        {
            temporaryRotationY += 1;
            increasingRotation = new Quaternion(this.transform.rotation.x, temporaryRotationY, this.transform.rotation.z,0);
        }

    }
    public void SetPlayerRotation(float aFloat)
    {
        playerRotation.y = aFloat;
    }
    public void SetPlayerPosition(Vector3 aVector3)
    {
        playerPosition = aVector3;
    }
}
