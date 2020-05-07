using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : GenericEnemy
{
    private void Awake()
    {
        target = GameObject.Find("target");
    }
    void Start()
    {
        canAttack = true;
        state = STATES.WONDERING;
        health = 100;
        wonderingSpeed = 2;
        chaseSpeed = 5;
        attackSpeed = 4.0f;
        turnSpeed = 7;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackSpeed)
        {
            canAttack = true;
            
        }
        
        distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > 2)
        {
            state = STATES.CHASE;
        }
        else if (distance < 2 && canAttack == true)
        {
            state = STATES.ATTACK;
        }
        Movement();
    }

    private void Movement()
    {
        switch (state)
        {
            case STATES.WONDERING:

                break;

            case STATES.CHASE:
                EnemyRotation();
                transform.position += transform.forward * Time.deltaTime * chaseSpeed;
                break;

            case STATES.ATTACK:
                state = STATES.WONDERING;
                canAttack = false;
                timer = 0;
                EnemyRotation();
                Debug.Log("Attacking");
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
}
