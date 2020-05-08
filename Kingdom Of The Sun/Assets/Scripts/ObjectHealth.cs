using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    private int health;

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
        health -= n;
        if(health <= 0)
        {
            AnimationHandler animator = GetComponentInParent<AnimationHandler>();
            animator.setAnimation(0 /*a Number */);
            
            //display death animation
        }
    }
}
