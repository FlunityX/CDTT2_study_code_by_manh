using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

   

    public void PlayerIdleAnim()
    {
        animator.CrossFade("main_idle", .2f, 0);
    }
    public void PlayRunAnim()
    {
        animator.CrossFade("main_run", .2f, 0);
    }
    public void PlayJumpAnim()
    {
        animator.CrossFade("main_jump", .2f, 0);
    }
    public void PlayFallAnim()
    {
        animator.CrossFade("main_fall", .2f, 0);
    }
}
