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

    private IEnumerator Death()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        yield return new WaitForSeconds(clips[0 /* death anim clip number */].length);
    }
}
