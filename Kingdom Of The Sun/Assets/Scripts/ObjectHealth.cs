using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    Renderer rend;
    [SerializeField] private Material[] debugMat;
    private int health;

    private void Start()
    {
        health = 100;
        rend = GetComponent<Renderer>();    
    }

    public void setHealth(int n)
    {
        health = n;
    }

    public int getHealth()
    {
        return health;
    }

    public void TakeDamage(int n)
    {
        StartCoroutine(DebugHealth());
        health -= n;
        if(health <= 0)
        {
            //AnimationHandler animator = GetComponentInParent<AnimationHandler>();
            //animator.setAnimation(0 /*a Number */); //display death animation
            Destroy(gameObject);
        }
    }

    private IEnumerator DebugHealth()
    {
        rend.material = debugMat[0];
        yield return new WaitForSeconds(0.3f);
        rend.material = debugMat[1];
    }
}
