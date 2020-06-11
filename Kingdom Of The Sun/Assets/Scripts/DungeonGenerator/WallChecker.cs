using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : RoomSpawner
{
    private bool[] directionsOpen;
    private Vector3 raycastStartPosition;
    private Vector3 raycastDirection;
    private float maxRaycastDistance;
    private int layer = 8;
    private float degrees = 0;
    private bool rotating = false;
    private float distance;
    private void Start()
    {
        CheckWall();
    }
    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(transform.position, Vector3.forward, Color.green);

    }
    private void Rotate()
    {
        rotating = true;
        raycastDirection = new Vector3(0, 0, 0);
        Vector3 currentDegrees;
        float x = this.transform.rotation.x;
        currentDegrees = new Vector3(x += 90f, this.transform.rotation.y, this.transform.rotation.z);
        transform.localRotation = Quaternion.Euler(currentDegrees);
        //currentDegrees = Quaternion.AngleAxis(90, Vector3.up) * raycastDirection;
        //degrees += 90;
        rotating = false;
    }

    private void CheckWall()
    {
        RaycastHit hit;
        
        if (rotating == false)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Physics.Raycast(transform.position, Vector3.forward, out hit,30, layer))
                {
                    //Debug.Log("Trigger");
                    //Debug.DrawRay(transform.position, Vector3.forward, Color.yellow);
                    if (Vector3.Distance(transform.position, hit.transform.position) > 15)
                    {
                        directionsOpen[i] = true;
                        // Debug.Log(directionsOpen[i]);
                        Rotate();
                    }
                }
                else 
                {
                    //Debug.Log("oof");
                    Rotate();
                }
            }
        }
    }
}