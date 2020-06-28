using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFix : MonoBehaviour
{
    public GameObject rightWrist;

    private void LateUpdate()
    {
        Vector3 invert = rightWrist.transform.position;
        invert.z = -invert.z;
        gameObject.transform.position = invert;

    }
}
