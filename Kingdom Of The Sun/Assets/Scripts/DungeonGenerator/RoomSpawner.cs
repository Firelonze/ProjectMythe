using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomSpawner : Test
{
    private string arrayName;
    private float x;
    private float y;
    private float z;
    protected int rand;
    protected bool spawned = false;
    private void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
    }
    public void Spawn()
    {
        //Debug.Log(neededArray);
        switch (arrayName)
        {
            case "openBottom":
                rand = Random.Range(0, openBottom.Length);
                Instantiate(openBottom[rand], new Vector3(this.transform.position.x, y-0.5f, z += 1), Quaternion.identity);
                y = this.transform.position.y;
                z = this.transform.position.z;
                arrayName = "";
                //spawning = false;
                break;
            case "openLeft":
                rand = Random.Range(0, openLeft.Length);
                Instantiate(openLeft[rand], new Vector3(x += 1, y - 0.5f, this.transform.position.z), Quaternion.identity);
                x = this.transform.position.x;
                y = this.transform.position.y;
                arrayName = "";
                //spawning = false;
                break;
            case "openTop":
                rand = Random.Range(0, openTop.Length);
                Instantiate(openTop[rand], new Vector3(this.transform.position.x, y - 0.5f, z -= 1), Quaternion.identity);
                y = this.transform.position.y;
                z = this.transform.position.z;
                arrayName = "";
                //spawning = false;
                break;
            case "openRight":
                rand = Random.Range(0, openRight.Length);
                Instantiate(openRight[rand], new Vector3(x -= 1, y - 0.5f, this.transform.position.z), Quaternion.identity);
                x = this.transform.position.x;
                y = this.transform.position.y;
                arrayName = "";
                //spawning = false;
                break;
        } 
    }
    public void SetOpeningDirectionArray(string aDirection)
    {
        arrayName = aDirection;
    }
}
