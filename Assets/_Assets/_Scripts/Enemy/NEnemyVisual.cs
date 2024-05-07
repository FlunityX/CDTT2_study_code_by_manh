using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyVisual : MonoBehaviour
{
   [SerializeField] private Animator animator;
   [SerializeField] private SpriteRenderer sprite;
    [SerializeField]private NormalEnemy _normalEnemy;
    private string _name;
    private void Start()
    {
       // animator = GetComponent<Animator>();
        _name = _normalEnemy.GetEnemyStat().GetUnitSO().UnitName;
    }

    public void PlayIdleAnim()
    {
        animator.CrossFade(_name + "_idle", .2f, 0);
    }
    public void PlayWalkAnim()
    {
        animator.CrossFade(_name + "_walk", .2f, 0);
    }
    public void PlayAttackAnim()
    {
        animator.CrossFade(_name + "_attack", .2f, 0);
        
    }
    public void PlayHurtAnim()
    {
        animator.CrossFade(_name + "_hurt", .2f, 0);
    }
    public void PlayDeadAnim()
    {
        animator.CrossFade(_name + "_dead", .2f, 0);
    }
    public void Invisible()
    {
        sprite.enabled = false;
    }
    public void Visiable()
    {
        sprite.enabled = true;
    }
}
