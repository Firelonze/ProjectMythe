using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : GenericEnemy
{
    void Start()
    {
        target = GameObject.Find("target");
        state = STATES.WONDERING;
        health = 100;
        walkingSpeed = 10;
        attackSpeed = 10;
        turnSpeed = 5;
    }

    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
        Debug.Log(distance);
        if (distance < 1)
        {
            state = STATES.ATTACK;
        }
        if (distance < 10)
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
        //do attack
        yield return new WaitForSeconds(speed);
        Debug.Log("Yeet");
    }
}
