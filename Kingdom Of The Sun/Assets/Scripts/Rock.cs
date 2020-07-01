using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject chain;
    private void Update()
    {
        if (chain == null)
        {
            this.transform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == 8)
        {
            gameObject.transform.parent = other.transform;
        }
    }
}
