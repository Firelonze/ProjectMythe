using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerSpeedTracker : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    protected Vector3 playerPosition;
    protected Quaternion playerRotation;
    private Vector3 lastPos;
    protected int movesSpeed;
    void Start()
    {
        StartCoroutine(CalcVelocity());
    }
    private void Update()
    {
        
    }
    IEnumerator CalcVelocity()
    {
        while (Application.isPlaying)
        {
            lastPos = player.transform.position;
            yield return new WaitForFixedUpdate();
            movesSpeed = Mathf.RoundToInt(Vector3.Distance(player.transform.position, lastPos) / Time.fixedDeltaTime);
        }
    }
}
