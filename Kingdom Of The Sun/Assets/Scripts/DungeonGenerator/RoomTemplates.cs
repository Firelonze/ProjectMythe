using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [SerializeField] protected GameObject[] topRooms;
    [SerializeField] protected GameObject[] bottomRooms;
    [SerializeField] protected GameObject[] rightRooms;
    [SerializeField] protected GameObject[] leftRooms;

    [SerializeField] protected GameObject closedRooms;

    //Dictionary<int, List<GameObject>> Rooms = new Dictionary<int, List<GameObject>>();
    private void Start()
    {
        //Rooms[1] = new List<GameObject>();
        //Debug.Log(Rooms[1]);
        //inventory[Keys.MACHINE_GUN] = new List<GameObject>();
        //Rooms[1].Add(topRooms[0]);

    }

}
