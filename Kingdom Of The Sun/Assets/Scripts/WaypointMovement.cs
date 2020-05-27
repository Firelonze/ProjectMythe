using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    private GameObject[] waypoints;
    private int currentWaypoint;
    [SerializeField] private int turnSpeed = 7;
    AudioHandler audiohandler;
    private float waypointDistance;

    private float timer;

    private Transform target;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("TezcoWaypoints");
    }

    private void Update()
    {
        waypointDistance = Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position);


        timer += Time.deltaTime;

        if(timer < 4)
        {
            Floating();
        }
        else
        {
            if (waypointDistance < 1)
            {
                if (currentWaypoint == waypoints.Length)
                {
                    currentWaypoint = -1;
                }
                currentWaypoint++;
                timer = 0;
            }
            EnemyRotation();
            Walking(4);
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

    private void Floating()
    {
        transform.position = new Vector3(0, Mathf.Sin(Time.time * 3) / Mathf.PI / 7, 0);
    }
}
