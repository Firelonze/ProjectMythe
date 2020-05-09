using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : GenericEnemy
{
    private void Awake()
    {
        animationHandler = GetComponent<AnimationHandler>();
        target = GameObject.Find("target");
    }
    void Start()
    {
        canAttack = true;
        state = STATES.WANDERING;
        health = 100;
        wanderingSpeed = 2;
        chaseSpeed = 2;
        chaseSpeed = 2;
        attackSpeed = 1;
        turnSpeed = 7;
    }

    void Update()
    {
        timer += Time.deltaTime;

        distance = Vector3.Distance(target.transform.position, transform.position);

        if (timer > attackDelay)
        {
            canAttack = true;
        }

        if(distance > 15)
        {
            state = STATES.WANDERING;
        }
        if (distance > 2 && distance < 15)
        {
            state = STATES.CHASE;
        }
        else if (distance < 3 && canAttack == true)
        {
            state = STATES.ATTACK;
        }
        Movement();
    }

    private void Movement()
    {
        switch (state)
        {
            case STATES.WANDERING:

                break;

            case STATES.CHASE:
                EnemyRotation();
                Walking(chaseSpeed);
                break;

            case STATES.ATTACK:
                state = STATES.WANDERING;
                canAttack = false;
                timer = 0;
                EnemyRotation();
                if(distance > 1.5f)
                {
                    Walking(attackSpeed);
                }
                animationHandler.setAnimation(0 /*attack animation number*/);
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
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
