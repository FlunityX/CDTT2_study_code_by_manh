using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.U2D;

public class BossVisual : MonoBehaviour
{
    [SerializeField] private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayBossIdelAnim()
    {
        animator.CrossFade(GameConstant.BOSS_IDLE_ANIM, .2f, 0);
    }
    public void PlayBossWalkAnim()
    {
        animator.CrossFade(GameConstant.BOSS_WALK_ANIM, .2f, 0);
    }
    public void PlayBossAttackAnim()
    {
        animator.CrossFade(GameConstant.BOSS_ATTACK_ANIM, .2f, 0);
    }
    public void PlayBossSpellAnim()
    {
        animator.CrossFade(GameConstant.BOSS_SPELL_ANIM, .2f, 0);
    }
    public void PlayBossHurtAnim()
    {
        animator.CrossFade(GameConstant.BOSS_HURT_ANIM, .2f, 0);
    }
    public void PlayBossDeadAnim()
    {
        animator.CrossFade(GameConstant.BOSS_DEAD_ANIM, .2f, 0);
    }
    public void PlayBossAppearAnim()
    {
        animator.CrossFade(GameConstant.BOSS_APPEAR_ANIM, .2f, 0);
        

    }
    public void PlayBossDisappearAnim()
    {
        
        animator.CrossFade(GameConstant.BOSS_DISAPPEAR_ANIM, .1f, 0);
        Debug.Log("Hide");
    }
    public void Invisible()
    {
        gameObject.SetActive(false);

    }
    public void Visible()
    {
        gameObject.SetActive(true);
    }

   
    
}
