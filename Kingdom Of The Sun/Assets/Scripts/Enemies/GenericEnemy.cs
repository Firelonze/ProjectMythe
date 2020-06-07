using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    [SerializeField] protected Transform curWaypoint;
    [SerializeField] protected float waypointDistance;
    [SerializeField] protected int currentWaypoint;

    [SerializeField] protected Transform player;

    protected Renderer rend;

    protected WeaponCollision weaponCollision;
    [SerializeField] protected AudioHandler audioHandler;

    protected float timer; 

    //animation related variables
    [SerializeField] protected AnimationHandler animationHandler;

    //states of the Enemy
    protected enum STATES
    {
        WANDERING,
        CHASE,
        ATTACK,
        RAGE
    }

    //The target it will attempt to attack
    protected Transform target;
    
    //distance between player and this Enemy
    [SerializeField] protected float distance;

    private void Awake()
    {
        //audioHandler = GetComponent<AudioHandler>();
        /*
        try
        {
            rend = GetComponent<Renderer>();
        }
        catch(Exception e)
        {
            print(e);
        }
        */
        animationHandler = GetComponent<AnimationHandler>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
}
