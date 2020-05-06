using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    //base stats Enemy
    protected int health;
    protected int damage;
    protected int walkingSpeed;
    protected int turnSpeed;
    protected float attackSpeed;
    protected STATES state;

    protected float timer;

    //animation related variables
    protected Animator animator;

    //states of the Enemy
    protected enum STATES
    {
        WONDERING,
        CHASE,
        ATTACK
    }

    //The target it will attempt to attack
    protected GameObject target;
    
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
