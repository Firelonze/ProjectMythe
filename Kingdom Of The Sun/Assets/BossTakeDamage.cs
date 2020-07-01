using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTakeDamage : MonoBehaviour
{
    AnimationHandler animHandler;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 14)
        {
            GameObject.Find("Boss").GetComponent<BossHealth>().health -= 1;

            animHandler.setAnimation(1/*damage anim*/);
        }
    }
}