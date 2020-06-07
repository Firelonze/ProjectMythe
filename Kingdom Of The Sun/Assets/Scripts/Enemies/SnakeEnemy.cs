using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnemy : GenericEnemy
{
    private ObjectHealth objHealth;

    private void Awake()
    {
        objHealth = GetComponent<ObjectHealth>();
        weaponCollision = GetComponentInChildren<WeaponCollision>();
        audioHandler = GetComponent<AudioHandler>();
        damage = 1;
    }

    private void Start()
    {
        weaponCollision.setDamage(damage);
        attackDelay = 2;
        canAttack = true;
        state = STATES.WANDERING;
        wanderingSpeed = 2;
        chaseSpeed = 1;
        attackSpeed = 4;
        turnSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        timer += Time.deltaTime;

        if (distance < 15)
        {
            if (distance < 3 && canAttack == true)
            {
                state = STATES.ATTACK;
            }
            else if (distance > 2 && distance < 15)
            {
                state = STATES.CHASE;
            }
        }
        else
        {
            state = STATES.WANDERING;
        }

        if (timer > attackDelay)
        {
            canAttack = true;
        }

        Movement();
    }

    private void Movement()
    {
        switch (state)
        {
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
                break;

            case STATES.CHASE:
                target = player;

                if (distance > 0.50f)
                {
                    Walking(chaseSpeed);
                }
                break;

            case STATES.ATTACK:
                state = STATES.CHASE;
                canAttack = false;
                timer = 0;
                if (distance > 0.50f)
                {
                    Walking(attackSpeed);
                }
                else
                {
                    animationHandler.setAnimation(1);
                }
                break;
        }
        EnemyRotation();
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
        animationHandler.setAnimation(2);
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
