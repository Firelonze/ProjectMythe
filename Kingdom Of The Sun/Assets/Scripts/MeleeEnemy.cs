using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : GenericEnemy
{
    private int i;
    [SerializeField] private Material[] debugMats;
    private void Awake()
    {
        audioHandler = GetComponent<AudioHandler>();
        rend = GetComponent<Renderer>();
        animationHandler = GetComponent<AnimationHandler>();
        player = GameObject.Find("Player");
    }
    void Start()
    {
        attackDelay = 2;
        i = 0;
        canAttack = true;
        state = STATES.WANDERING;
        health = 100;
        wanderingSpeed = 4;
        chaseSpeed = 2;
        attackSpeed = 1;
        turnSpeed = 7;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(target != null || player != null)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);

            waypointDistance = Vector3.Distance(waypoints[i].transform.position, transform.position);

            if (waypointDistance < 1)
            {
                if (i == 3)
                {
                    i = -1;
                }
                i++;
            }

            if (timer > attackDelay)
            {
                canAttack = true;
            }

            if (distance > 15)
            {
                state = STATES.WANDERING;
                rend.material = debugMats[0];
            }
            else if (distance < 3 && canAttack == true)
            {
                state = STATES.ATTACK;
            }
            else if (distance > 2 && distance < 15)
            {
                state = STATES.CHASE;
                rend.material = debugMats[1];
            }

            Movement();
        }
    }

    private void Movement()
    {
        switch (state)
        {
            case STATES.WANDERING:
                target = waypoints[i].gameObject;
                Walking(wanderingSpeed);
                break;

            case STATES.CHASE:
                target = player;

                if (distance > 1.5f)
                {
                    Walking(chaseSpeed);
                }
                else
                {
                    audioHandler.StopAudioFootsteps();
                }
                break;

            case STATES.ATTACK:
                audioHandler.PlayAudioSFX(1);
                Debug.Log("attacking");
                player.GetComponent<ObjectHealth>().TakeDamage(25);
                //state &= ~STATES.ATTACK;
                state = STATES.CHASE;
                canAttack = false;
                timer = 0;
                if (distance > 1.5f)
                {
                    Walking(attackSpeed);
                }
                else
                {

                }
                //animationHandler.setAnimation(0 /*attack animation number*/);
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
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
