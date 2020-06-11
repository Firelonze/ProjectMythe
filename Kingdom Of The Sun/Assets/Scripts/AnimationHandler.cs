using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void setAnimation(int i)
    {
        animator.SetInteger("AnimState", i /*animation state*/);
        if(i == 0 /*whatever number is the death anim*/)
        {
            StartCoroutine(Death());
        }
    }

    public void PlayAnim(string name)
    {
        animator.Play(name);
    }

    private IEnumerator Death()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        yield return new WaitForSeconds(clips[0 /* death anim clip number */].length);
        Destroy(gameObject);
    }

    public void PauseAnim(bool temp_bool)
    {
        animator.enabled = temp_bool;
    }

    public float getAnimationClipLength()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public int getAnimationState()
    {
        return animator.GetInteger("AnimState");
    }
}
