using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BossHealth : MonoBehaviour
{
    public int health;



    private void Update()
    {
        if(health == 0)
        {

            GameObject.Find("Camera").gameObject.transform.parent = null;
            GameObject.Find("Player").SetActive(false);
            GameObject.Find("CrossHair").SetActive(false);
            GameObject.Find("Subs").SetActive(false);
            GameObject.Find("Image").SetActive(false);

            GameObject.Find("EndingCinematic").GetComponent<VideoPlayer>().Play();
            //do cutsccene
        }
    }
}
