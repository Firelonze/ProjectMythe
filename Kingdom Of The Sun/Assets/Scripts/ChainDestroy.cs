using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12) 
        {
            Destroy(gameObject);
        }
    }
}
