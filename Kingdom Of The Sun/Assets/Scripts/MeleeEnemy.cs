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
        walkingSpeed = 10;
        attackSpeed = 10;
        turnSpeed = 2;
    }

    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
        Debug.Log(distance);
        if (distance < 2 && canAttack)
        {
            state = STATES.ATTACK;
        }
        if (distance > 2 && distance < 10)
        {
            state = STATES.CHASE;
        }
        if (distance > 10)
        {
            state = STATES.WONDERING;
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
                Vector3 dir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
                transform.rotation = Quaternion.Euler(0, rotation.y, 0);
                break;

            case STATES.ATTACK:
                Debug.Log("Attacking");
                StartCoroutine(Attack(attackSpeed));
                break;
        }
    }

    private IEnumerator Attack(float speed)
    {
        canAttack = false;

        //do attack
        yield return new WaitForSeconds(speed);
        Debug.Log("Yeet");
        canAttack = true;
    }
}
