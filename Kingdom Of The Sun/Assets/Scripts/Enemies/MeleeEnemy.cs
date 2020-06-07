using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : GenericEnemy
{
    [SerializeField] private Material[] debugMats;

    void Start()
    {
        attackDelay = 2;
        canAttack = true;
        state = STATES.WANDERING;
        wanderingSpeed = 2;
        chaseSpeed = 1;
        attackSpeed = 4;
        turnSpeed = 7;
    }

    void Update()
    {
        timer += Time.deltaTime;
        target = player;
        if (target != null || player != null)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);

            //waypointDistance = Vector3.Distance(waypoints[i].transform.position, transform.position);

            /*if (waypointDistance < 1)
            {
                if (i == 3)
                {
                    i = -1;
                }
                i++;
            }*/

            if (timer > attackDelay)
            {
                canAttack = true;
            }

            if (distance > 15)
            {
                state = STATES.WANDERING;
            }
            else if (distance < 3 && canAttack == true)
            {
                state = STATES.ATTACK;
            }
            else if (distance > 2 && distance < 15)
            {
                state = STATES.CHASE;
            }
            Movement();
        }
        else
        {
            animationHandler.setAnimation(100);
        }
    }

    private void Movement()
    {
        //animationHandler.setAnimation(100);
        switch (state)
        {
            case STATES.WANDERING:
                //target = null;
                //Walking(wanderingSpeed);
                break;

            case STATES.CHASE:
                target = player;

                if (distance > 0.50f)
                {
                    Walking(chaseSpeed);
                }
                else
                {
                    animationHandler.setAnimation(10);
                }
                break;

            case STATES.ATTACK:
                //audioHandler.PlayAudioSFX(0);
                
                state = STATES.CHASE;
                canAttack = false;
                timer = 0;
                if (distance > 0.50f)
                {
                    Walking(attackSpeed);
                }
                else
                {
                    animationHandler.setAnimation(3);
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
