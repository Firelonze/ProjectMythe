﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerSpeedTracker : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected Vector3 playerPosition;
    protected Vector3 playerRotation;
    private Vector3 lastPos;
    protected int movesSpeed;
    void Start()
    {
        StartCoroutine(CalcVelocity());
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

    public int GetSpeed()
    {
        return movesSpeed;
    }
}
