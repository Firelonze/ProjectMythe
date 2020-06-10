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
    [SerializeField] protected int rageChaseSpeed;
    [SerializeField] protected int rageAttackSpeed;
    [SerializeField] protected int rageWanderingSpeed;
    [SerializeField] protected int turnSpeed;
    [SerializeField] protected int attackSpeed;
    [SerializeField] protected float attackDelay;
    [SerializeField] protected bool canAttack;
    [SerializeField] protected bool canMove = true;

    [SerializeField] protected Transform[] waypoints;
    [SerializeField] protected Transform curWaypoint;
    [SerializeField] protected float waypointDistance;
    [SerializeField] protected int currentWaypoint;
    protected ObjectHealth objHealth;

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
        RAGE_WANDERING,
        RAGE_CHASE,
        RAGE_ATTACK,
        IDLE,
        RAGE_IDLE
    }
    [SerializeField] protected STATES state;

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

    public void SetCanMove(bool temp_bool)
    {
        canMove = temp_bool;
    }
}
