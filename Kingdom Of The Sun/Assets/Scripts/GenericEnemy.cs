using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    //base stats Enemy
    protected int health;
    protected int damage;
    protected int walkingSpeed;
    protected int attackSpeed;
    protected STATES state;

    //states of the Enemy
    protected enum STATES
    {
        WONDERING,
        CHASE,
        ATTACK
    }

    //target of this Enemy and target it will attempt to attack
    protected GameObject target;
    protected Vector3 ownPosition;
    
    //distance between player and this Enemy
    protected float distance;

    public void setHealth(int tempHealth)
    {
        health = tempHealth;
    }

    public void setDamage(int damage)
    {
        health -= damage;
    }
}
