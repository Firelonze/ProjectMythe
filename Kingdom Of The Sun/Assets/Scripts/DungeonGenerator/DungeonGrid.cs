using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class DungeonGrid : RoomTemplates
{
    protected int leftRight, upDown;


    protected int[,] intMap = new int[,]{
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,1,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 }};


    private void Start()
    {
        for (int i = 0; i < intMap.GetUpperBound(0); i++)
        {
            //for (int j = 0; j < intMap.GetUpperBound(Random.Range(0,6)); j++)
            for (int j = 0; j < intMap.GetUpperBound(1); j++)
            {
                leftRight = i;
                upDown = j;    
            }
        }
    }
}
