using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    //base stats Enemy
    [SerializeField] protected int damage;
    [SerializeField] protected int wanderingSpeed;
    [SerializeField] protected int chaseSpeed;
    [SerializeField] protected int turnSpeed;
    [SerializeField] protected int attackSpeed;
    [SerializeField] protected float attackDelay;
    [SerializeField] protected STATES state;
    [SerializeField] protected bool canAttack;
    [SerializeField] protected Transform[] waypoints;
    [SerializeField] protected float waypointDistance;

    [SerializeField] protected GameObject player;

    protected Renderer rend;

    protected WeaponCollision weaponCollision;
    [SerializeField] protected AudioHandler audioHandler;

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
    [SerializeField] protected float distance;
}
