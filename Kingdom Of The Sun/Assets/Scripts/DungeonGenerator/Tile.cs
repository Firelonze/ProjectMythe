using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Tile : DungeonGrid
{
    private void PercentageRandomizer()
    {
        Random.Range(0, 100);
    }
    public void TileSpawner()
    {

        //Debug.Log(upDown);
        //Debug.Log(leftRight);

        if (upDown == 5 && leftRight == 5)
        {
            Debug.Log("CenterSpawned");
            Instantiate(center[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
            StartCoroutine(WaitForSeconds());
        }

    }
}
 