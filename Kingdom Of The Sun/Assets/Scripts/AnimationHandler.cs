using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;

    public void setAnimation(int i)
    {
        animator.SetInteger("IntName", 1 /*animation state*/);
    }

}
