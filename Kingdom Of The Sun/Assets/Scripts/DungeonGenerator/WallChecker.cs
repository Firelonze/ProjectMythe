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
    /*private void FixedUpdate()
    {
        print("1");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, layer))
        {
            print("2");
            switch (degrees)
            {
                case 0:
                    Rotate();
                    break;
                case 90:
                    Rotate();
                    break;
                case 180:
                    Rotate();
                    break;
                case 270:
                    Destroy(gameObject);
                    break;
            }
        }
        else if (!Physics.Raycast(transform.position, Vector3.forward, out hit, layer))
        {
            print("3");
            switch (degrees)
            {
                case 0:
                    openingDirection = 1;
                    Rotate();
                    break;
                case 90:
                    openingDirection = 2;
                    Rotate();
                    break;
                case 180:
                    openingDirection = 3;
                    Rotate();
                    break;
                case 270:
                    openingDirection = 4;
                    Destroy(gameObject);
                    break;
            }
        }

    }*/
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
                //Debug.Log("Triggered");
                if (Physics.Raycast(transform.position, Vector3.forward, out hit,30, layer))
                {
                    Debug.Log("Trigger");
                    Debug.DrawRay(transform.position, Vector3.forward, Color.yellow);
                    //distance = Vector3.Distance(hit.transform.position, transform.position);
                    if (Vector3.Distance(transform.position, hit.transform.position) > 15)
                    {
                        directionsOpen[i] = true;
                        Debug.Log(directionsOpen[i]);
                        Rotate();
                    }
                }
                else 
                {
                    Debug.Log("oof");
                    Rotate();
                    //openingDirection = i;
                }
            }
        }
    }
}