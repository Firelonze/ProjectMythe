using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrain : MonoBehaviour
{
    bool allowedToStart;
    Rigidbody rb;
    float speed = 1000.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(start());
    }

    void Update()
    {
        if (allowedToStart) 
        {
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
    }

    IEnumerator start() 
    {
        yield return new WaitForSeconds(1);
        allowedToStart = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 14) 
        {
            // boss neemt damage
            // boss gaat weg
            // boss 
            GameObject Boss = GameObject.Find("Boss");
            Boss.GetComponent<BossHealth>().health -= 1;
            Boss.GetComponent<BossAttacks>().reappear();
            Destroy();
        }
        if (other.gameObject.layer == 9) 
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Destroy()
    {
        GetComponent<Animator>().Play("damage");
        AnimationClip[] clips = GetComponent<Animator>().runtimeAnimatorController.animationClips;
        yield return new WaitForSeconds(clips[0 /* death anim clip number */].length);
        Destroy(gameObject);
    }
}
