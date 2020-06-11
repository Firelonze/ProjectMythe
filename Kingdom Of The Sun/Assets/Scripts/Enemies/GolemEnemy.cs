using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : GenericEnemy
{
    private bool canRage;
    private bool isRaged;
    private float rageTimer;
    private bool isAwakened;
    private bool goFuckYourself;

    private void Awake()
    {
        objHealth = GetComponent<ObjectHealth>();
        weaponCollision = GetComponentInChildren<WeaponCollision>();
        audioHandler = GetComponent<AudioHandler>();
        damage = 1;
    }

    private void Start()
    {
        canAttack = true;
        isRaged = false;
        isAwakened = false;
        canRage = true;

        animationHandler.PauseAnim(false);
        weaponCollision.setDamage(damage);
        attackDelay = 5;
        canAttack = true;
        state = STATES.WANDERING;
        wanderingSpeed = 2;
        chaseSpeed = 2;
        rageChaseSpeed = 4;
        attackSpeed = 4;
        turnSpeed = 7;
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        timer += Time.deltaTime;
        rageTimer += Time.deltaTime;

        //this is utterly fucking retarded FIX THIS
        if (isAwakened)
        {
            print(state);
            if (distance < 15 && canRage)
            {
                isRaged = true;
                canRage = false;
                StartCoroutine(RageCooldown());
            }
            if (isRaged && distance < 2 && canAttack)
            {
                state = STATES.RAGE_ATTACK;
            }
            else if (isRaged && !canAttack)
            {
                state = STATES.RAGE_IDLE;
            }
            else if (isRaged && distance < 15)
            {
                state = STATES.RAGE_CHASE;
            }
            else if (!isRaged && distance < 15)
            {
                state = STATES.CHASE;
            }
            else if (!isRaged)
            {
                state = STATES.WANDERING;
            }

            if (timer > 2.5f)
            {
                canAttack = true;
            }
            Movement();
        }

        if(!goFuckYourself && distance < 15)
        {
            goFuckYourself = true;
            animationHandler.PauseAnim(true);
            StartCoroutine(Awaken());
        }
    }

    private void Movement()
    {
        switch (state)
        {
            case STATES.RAGE_IDLE:
                animationHandler.setAnimation(100);
                break;

            case STATES.WANDERING:
                waypointDistance = Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position);
                target = waypoints[currentWaypoint].transform;
                if (waypointDistance < 2)
                {
                    if (currentWaypoint == waypoints.Length - 1)
                    {
                        currentWaypoint = -1;
                    }
                    currentWaypoint++;
                }
                Walking(wanderingSpeed);
                
                EnemyRotation();
                break;

            case STATES.RAGE_WANDERING:
                target = player;
                Walking(rageWanderingSpeed);
                EnemyRotation();
                break;

            case STATES.CHASE:
                target = player;
                Walking(chaseSpeed);
                EnemyRotation();
                break;

            case STATES.RAGE_CHASE:
                target = player;
                Walking(rageChaseSpeed);
                EnemyRotation();
                break;

            case STATES.RAGE_ATTACK:
                target = player;
                timer = 0;
                canAttack = false;
                animationHandler.setAnimation(1);
                break;
        }
    }

    private void EnemyRotation()
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    private void Walking(int speed)
    {
        if (state == STATES.RAGE_CHASE)
        {
            animationHandler.setAnimation(2);
        }
        else
        {
            animationHandler.setAnimation(3);
        }
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private IEnumerator RageCooldown()
    {
        yield return new WaitForSeconds(15);
        isRaged = false;
        yield return new WaitForSeconds(5);
        canRage = true;
    }

    private IEnumerator Awaken()
    {
        yield return new WaitForSeconds(animationHandler.getAnimationClipLength());
        isAwakened = true;
    }
}
