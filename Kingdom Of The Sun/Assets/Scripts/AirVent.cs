using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVent : MonoBehaviour
{
    public GameObject player;
    private float jumpHeight = 5.5f;
    Vector3 velocity;
    private float gravity = -19.62f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            player.GetComponent<PlayerMovement>().velocity.y = velocity.y;
        }

        if (other.gameObject.layer == 8) 
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            GetComponent<ParticleSystem>().Play();
        }
    }
}
