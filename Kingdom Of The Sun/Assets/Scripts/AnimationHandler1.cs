using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler1 : MonoBehaviour
{
    private Animator animator;
    Animation animationComp;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void setAnimation(int i)
    {
        animator.SetInteger("AnimState", i /*animation state*/);
        if(i == 0 /*whatever number is the death anim*/)
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        yield return new WaitForSeconds(clips[0 /* death anim clip number */].length);
        Destroy(gameObject);
    }
}
