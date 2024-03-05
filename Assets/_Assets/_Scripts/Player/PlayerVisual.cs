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
        animator.CrossFade(GameConstant.PLAYER_IDLE_ANIM, .2f, 0);
    }
    public void PlayRunAnim()
    {
        animator.CrossFade(GameConstant.PLAYER_WALK_ANIM, .2f, 0);
    }
    public void PlayJumpAnim()
    {
        animator.CrossFade(GameConstant.PLAYER_JUMP_ANIM, .2f, 0);
    }
    public void PlayFallAnim()
    {
        animator.CrossFade(GameConstant.PLAYER_FALL_ANIM, .2f, 0);
    }
    public void PlayEntryAttackAnim()
    {
        animator.CrossFade(GameConstant.PLAYER_ENTRY_ATTACK_ANIM, .2f, 0);
    }
    public void PlayComboAttack1Anim()
    {
        animator.CrossFade(GameConstant.PLAYER_COMBO_ATTACK1_ANIM, .2f, 0);
    }
    public void PlayComboAttack2Anim()
    {
        animator.CrossFade(GameConstant.PLAYER_COMBO_ATTACK2_ANIM, .2f, 0);
    }
    public void PlayFinishAttackAnim()
    {
        animator.CrossFade(GameConstant.PLAYER_FINISH_ATTACK_ANIM, .2f, 0);
    }
    public void PlayAirAttackAnim()
    {
        animator.CrossFade(GameConstant.PLAYER_AIR_ATTACK_ANIM, .2f,0);
    }
    public void PlayAirAttackGroundAnim()
    {
        animator.CrossFade(GameConstant.PLAYER_AIR_ATTACK_GROUNDED_ANIM, .2f,0);

    }
}
