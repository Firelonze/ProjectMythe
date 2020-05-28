using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    private Renderer rend;
    public int health;

    private void Start()
    {
        health = 200;
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
        Debug.Log(gameObject.name + " health: " + health);
        health -= n;
        if(health <= 0)
        {

            Destroy(gameObject);
        }
    }
}
