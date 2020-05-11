using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : RoomTemplates
{
    [SerializeField]private int openingDirection = 1;
    // 1 is top
    // 2 is right
    // 3 is bottom
    // 4 is left

    private int rand;
    private bool spawned = false;
    private float waitTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {
            switch (openingDirection)
            {
                case 1:
                    rand = Random.Range(0, topRooms.Length);
                    Instantiate(topRooms[rand], transform.position, transform.rotation);
                break;
                case 2:
                    rand = Random.Range(0, rightRooms.Length);
                    Instantiate(rightRooms[rand], transform.position, transform.rotation);
                    break;
                case 3:
                    rand = Random.Range(0, bottomRooms.Length);
                    Instantiate(bottomRooms[rand], transform.position, transform.rotation);
                    break;
                case 4:
                    rand = Random.Range(0, leftRooms.Length);
                    Instantiate(leftRooms[rand], transform.position, transform.rotation);
                    break;
            }
            spawned = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                //blocks off opening
                Instantiate(closedRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
