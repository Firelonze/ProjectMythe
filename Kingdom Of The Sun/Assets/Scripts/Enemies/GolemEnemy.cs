using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : GenericEnemy
{
    private bool canRage;
    private bool isRaged;
    private float rageTimer;
    private void Awake()
    {
        objHealth = GetComponent<ObjectHealth>();
        weaponCollision = GetComponentInChildren<WeaponCollision>();
        audioHandler = GetComponent<AudioHandler>();
        damage = 1;
    }

    private void Start()
    {
        animationHandler.PauseAnim(false);
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
        rageTimer += Time.deltaTime;

        if(distance < 15 && canRage)
        {
            isRaged = true;
            canRage = false;
            StartCoroutine(RageCooldown());
            animationHandler.PauseAnim(true);
        }
        if(isRaged && distance < 2 && canAttack)
        {
            state = STATES.ATTACK;
        }
        else if (isRaged && !canAttack)
        {
            state = STATES.RAGE_IDLE;
        }
        else if(isRaged && distance < 15)
        {
            state = STATES.RAGE_CHASE;
        }
        else if(!isRaged)
        {
            if()
        }
        

        if(canMove)
        {
            Movement();
        }
        if(timer > 2)
        {
            canAttack = true;
        }

        Movement();
    }

    private void Movement()
    {
        switch (state)
        {
            case STATES.RAGE_IDLE:
                animationHandler.setAnimation(2);
                break;

            case STATES.WANDERING:
                Walking(wanderingSpeed);
                EnemyRotation();
                break;

            case STATES.RAGE_WANDERING:
                Walking(rageWanderingSpeed);
                EnemyRotation();
                break;

            case STATES.CHASE:
                Walking(chaseSpeed);
                EnemyRotation();
                break;

            case STATES.RAGE_CHASE:
                Walking(rageChaseSpeed);
                EnemyRotation();
                break;

            case STATES.RAGE_ATTACK:
                timer = 0;
                canAttack = false;
                animationHandler.setAnimation(5);
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
        if(state == STATES.RAGE_CHASE)
        {
            animationHandler.setAnimation(3);
        }
        else
        {
            animationHandler.setAnimation(4);
        }
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private IEnumerator RageCooldown()
    {
        yield return new WaitForSeconds(6);
        isRaged = false;
        yield return new WaitForSeconds(2);
        canRage = true;
    }
}
