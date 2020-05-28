using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : RoomTemplates
{
    //public bool spawning = false;
    //public string neededArray;
    private LayerMask layer = 8;
    private RoomSpawner roomSpawner;
    private float rotationYPosition;
    private int stepCounter;
    private void Start()
    {
        roomSpawner = gameObject.GetComponent<RoomSpawner>();
        InvokeRepeating("HitDetection", 0, 0.1f);
    }
    void HitDetection()
    {
        RaycastHit hit;
        if (GameObject.Find("Room limiter").GetComponent<RoomLimiter>().roomSpanwerOff == false)
        {

            if (Physics.Raycast(transform.position, this.transform.forward, out hit, layer))
            {
                //Debug.Log("hit");
                StartCoroutine(Rotator());
            }
            else
            {
                //Debug.Log("no hit");
                //if (spawning == false)

                //spawning = true;
                //Debug.Log(spawning);
                ChooseOpening();

            }
        }
    }
    void ChooseOpening()
    {
        switch (rotationYPosition)
        {
            case 0:
                //neededArray = "openBottom";
                roomSpawner.SetOpeningDirectionArray("openBottom");
                roomSpawner.Spawn();
                StartCoroutine(Rotator());
                //gameObject.GetComponent<RoomSpawner>().Spawn();
                break;
            case 90:
                //neededArray = "openLeft";
                roomSpawner.SetOpeningDirectionArray("openLeft");
                roomSpawner.Spawn();
                StartCoroutine(Rotator());
                break;
            case 180:
                //neededArray = "openTop";
                roomSpawner.SetOpeningDirectionArray("openTop");
                roomSpawner.Spawn();
                StartCoroutine(Rotator());
                break;
            case 270:
                //neededArray = "openRight";
                roomSpawner.SetOpeningDirectionArray("openRight");
                roomSpawner.Spawn();
                StartCoroutine(Rotator());
                break;
        }
    }
    IEnumerator Rotator()
    {
        transform.Rotate(Vector3.up * 90);
        rotationYPosition = gameObject.transform.rotation.eulerAngles.y;
        Mathf.Round(rotationYPosition);
        stepCounter++;
        if (stepCounter >= 4)
        {
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(0.1f);
    }
}


