using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLimiter : MonoBehaviour
{
    private GameObject[] rooms;
    public bool roomSpanwerOff = false;

    private void Start()
    {
        StartCoroutine(limit());
    }

    private IEnumerator limit()
    {
        yield return new WaitForSeconds(3);
        rooms = GameObject.FindGameObjectsWithTag("Room");
        foreach(GameObject room in rooms)
        {
            roomSpanwerOff = true;
        }
    }
}
