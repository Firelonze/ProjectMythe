using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;

        Debug.Log(collision.gameObject.name);

        if(obj.GetComponent<ObjectHealth>() != null)
        {
            obj.GetComponent<ObjectHealth>().TakeDamage(50);
        }
    }
}
