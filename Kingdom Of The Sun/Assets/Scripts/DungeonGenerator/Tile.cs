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
    private void Start()
    {
        switch (upDown)
        {
            case 0:
                if (upDown >= 1 && leftRight <= 7)
                //linker kant
                {
                    Debug.Log("upDown 1 werkt");
                    Instantiate(leftRow[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
                }
                if (leftRight == 0)
                    //linker boven hoek
                {
                    Debug.Log("upDown 2 werkt");
                    Instantiate(topLeftCorner[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
                }
                break;
            case 8:
                if (leftRight >= 1 && leftRight <= 7)
                    //rechter kant
                {
                    Debug.Log("upDown 3 werkt");
                    Instantiate(rightRow[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
                }
                if (leftRight == 8)
                    //rechter bodem
                {
                    Debug.Log("upDown 4 werkt");
                    Instantiate(bottomRightCorner[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
                }
                break;
        }
        switch (leftRight)
        {
            case 0:
                if (upDown >= 1 && leftRight <= 7)
                    //Top
                {
                    Debug.Log("leftRight werkt");
                    Instantiate(topRow[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
                }
                if (upDown == 8)
                    //left bottom
                {
                    Debug.Log("leftRight 2 werkt");
                    Instantiate(bottomLeftCorner[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
                }
                break;
            case 8:
                if (upDown >= 1 && leftRight <= 7)
                    //Bottom
                {
                    Debug.Log("leftRight 3 werkt");
                    Instantiate(bottomRow[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
                }
                if (upDown == 0)
                    //rechter top
                {
                    Debug.Log("leftRight 4 werkt");
                    Instantiate(topRightCorner[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
                }
                break;
        }
        if (upDown == 5 && leftRight == 5)
        {
            Debug.Log("CenterSpawned");
            Instantiate(center[intMap[upDown, leftRight]], new Vector3(upDown, 0, leftRight), Quaternion.identity);
        }

    }

}
 