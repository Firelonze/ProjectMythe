using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    //base stats Enemy
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected int wonderingSpeed;
    [SerializeField] protected int chaseSpeed;
    [SerializeField] protected int turnSpeed;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected STATES state;
    [SerializeField] protected bool canAttack;

    protected EnemyWeapon enemyWeapon;

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
