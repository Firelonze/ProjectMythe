using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public bool yes;
    private Renderer rend;
    private BloodEffects bloodEffects;
    public int health;

    private void Start()
    {
        rend = GetComponent<Renderer>();    
    }

    private void Update()
    {
        if(yes)
        {
            yes = false;
            TakeDamage(0);
        }
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
        if(health <= 0 && gameObject.name.Equals("Player"))
        {
            // lose screen
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
        if(gameObject.name.Equals("Player"))
        {
            bloodEffects = GameObject.Find("Image").GetComponent<BloodEffects>();
            bloodEffects.BloodEffect();
        }
    }
}
