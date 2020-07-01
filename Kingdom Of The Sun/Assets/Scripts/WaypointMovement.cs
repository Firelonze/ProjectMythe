using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint;
    [SerializeField] private int turnSpeed = 7;
    AudioHandler audiohandler;
    private float waypointDistance;
    private bool canMove;

    private Transform target;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("TezcaWay");
        target = waypoints[currentWaypoint].transform;
        canMove = true;
    }

    private void Update()
    {
        waypointDistance = Vector3.Distance(waypoints[currentWaypoint].transform.position, transform.position);
        
        if (waypointDistance < 2)
        {
            if (currentWaypoint == waypoints.Length - 1)
            {
                currentWaypoint = -1;
            }
            currentWaypoint++;
            target = waypoints[currentWaypoint].transform;
            StartCoroutine(timeOut());
        }
        if(canMove)
        {
            EnemyRotation();
            Walking(10);
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

    private IEnumerator timeOut()
    {
        canMove = false;
        yield return new WaitForSeconds(1);
        canMove = true;
    }
}
