using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        Vector3 yeet = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        //player.transform
        transform.LookAt(yeet);
    }

    public float getRotation()
    {
        return transform.rotation.eulerAngles.y;
    }
}
