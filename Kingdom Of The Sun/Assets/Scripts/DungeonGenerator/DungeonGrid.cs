using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class DungeonGrid : RoomTemplates
{
    protected int leftRight, upDown;
    [SerializeField] private GameObject gameobject;
    protected int  i, j;


    private void Start()
    {
        MapReader();
    }

    protected void MapReader()
    {
        

       // if (intMap[i,j] == 0) 
        {
//            intMap[i, j] = 2;
//            leftRight = i;
//            upDown = j;
//            gameobject.GetComponent<Tile>().TileSpawner();
        }
    }
}
