using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    //base stats Enemy
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected int wanderingSpeed;
    [SerializeField] protected int chaseSpeed;
    [SerializeField] protected int turnSpeed;
    [SerializeField] protected int attackSpeed;
    [SerializeField] protected float attackDelay;
    [SerializeField] protected STATES state;
    [SerializeField] protected bool canAttack;

    [SerializeField] protected WeaponCollision weaponCollision;

    protected float timer; 

    //animation related variables
    protected AnimationHandler animationHandler;

    //states of the Enemy
    protected enum STATES
    {
        WANDERING,
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
