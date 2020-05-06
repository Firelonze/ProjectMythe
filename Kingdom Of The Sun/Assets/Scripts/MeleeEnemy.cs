using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : GenericEnemy
{
    void Start()
    {
        state = STATES.WONDERING;
        health = 100;
        walkingSpeed = 10;
        attackSpeed = 10;
    }
    
    void Update()
    {
        
    }
}
