using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : GenericEnemy
{
    private bool isRaged;
    private bool canRage;
    private void Awake()
    {
        isRaged = false;
        objHealth = GetComponent<ObjectHealth>();
        weaponCollision = GetComponentInChildren<WeaponCollision>();
        audioHandler = GetComponent<AudioHandler>();
        damage = 1;
    }

    private void Start()
    {
        weaponCollision.setDamage(damage);
        attackDelay = 5;
        canAttack = true;
        state = STATES.WANDERING;
        wanderingSpeed = 2;
        chaseSpeed = 3;
        attackSpeed = 4;
        turnSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        timer += Time.deltaTime;
        
        if(distance < 5 && !isRaged && canRage)
        {
            animationHandler.setAnimation(1);
            isRaged = true;
        }
        if(distance < 15 && isRaged)
        {
            animationHandler.setAnimation(1);
            state = STATES.RAGE_CHASE;
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
            case STATES.IDLE:

                break;

            case STATES.RAGE_IDLE:

                break;

            case STATES.WANDERING:

                break;

            case STATES.RAGE_WANDERING:

                break;

            case STATES.CHASE:

                break;

            case STATES.RAGE_CHASE:

                break;

            case STATES.RAGE_ATTACK:

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
        animationHandler.setAnimation(2);
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
