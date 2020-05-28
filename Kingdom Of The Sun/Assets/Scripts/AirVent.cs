using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVent : MonoBehaviour
{
    public GameObject player;
    private float jumpHeight = 8f;
    Vector3 velocity;
    private float gravity = -19.62f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            player.GetComponent<PlayerMovement>().velocity.y = velocity.y;
        }
    }
}
