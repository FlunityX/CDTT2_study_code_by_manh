using UnityEngine;
using DG.Tweening;
using System.Collections;

public class BossManager : CharacterManager
{
    public Boss _Boss;
    
    public BossIdleState _IdleState = new();
    public BossWalkState _WalkState = new();
    public BossMeleeAttackState _MeleeAttack =new();
    public BossCastSpellState _CastSpellState = new();
    public BossHurtState _HurtState = new();
    public BossHiddingState _HiddingState = new();
    public BossAppearingState _AppearingState = new();
    public BossDeathState _DeathState = new();
    public float attackDuration = .5f;
    public float spellDuration = 5f;
    public float getHitDuration = .2f;
    public float hiddingDuration = 4f;
    public float appearingDuration = .5f;
    public float deadDuration = .5f;
    public float durationCounter;
    public float ChaseDir;
    private Tween moveTween;
    private void Start()
    {
        SetUpProperties();
    }
    protected override void Update()
    {
        base.Update();
    }
    private void SetUpProperties()
    {
        _state = _IdleState;
        _state.EnterState(this);
    }
    public bool CheckIfCanMeleeAttack()
    {
        return _Boss.GetBossMeleeAttack().IsReadyToAttack() && _Boss.attackCount < 3 && _Boss.GetBossCollider().isPlayerInRange;
    }
   
    public bool CheckIfCanUseSpell()
    {
        return _Boss.GetBossMeleeAttack().IsReadyToAttack() && _Boss.attackCount == 3;
    }

    public bool CheckIfGetHit()
    {
        return _Boss.isGetHit;
    }
    public bool CheckIfNeedChase()
    {
        return !_Boss.GetBossCollider().isPlayerInRange;
    }
    public bool CheckIfCanIdleSpellAttack()
    {
        return durationCounter >= spellDuration;
    }
    public bool CheckIfCanIdleMeleeAttack()
    {
        return durationCounter >= attackDuration;
    }
    public bool CheckIfCanIdleGetHit()
    {
        return durationCounter >= getHitDuration;
    }
    public bool CheckIfCanIdle()
    {
        return _Boss.GetBossCollider().isPlayerInRange;
    }
    public bool CheckIfCanAppear()
    {
        return durationCounter >= hiddingDuration;
    }
    public bool CheckIfCanAttackHidding()
    {
        return durationCounter > appearingDuration && _Boss.GetBossMeleeAttack().IsReadyToAttack();
    }
    public bool IsPlayerInAttackRange()
    {
        return _Boss.GetBossCollider().isPlayerInAttackRange;
    }
    public bool CheckIfCanUseHidding()
    {
        return _Boss.canUseHidding;
    }
    public bool CheckIfPlayerTooClose()
    {
        return Vector3.Distance(Player.Instance.transform.position, transform.position) <= 5f;
    }
    public bool CheckIfDead()
    {
        return _Boss.isDead;
    }
    public void Chase()
    {
       if (ChaseDir > 0)
        {
           
            moveTween =  transform.DOMoveX(transform.position.x +  1f, 1/ _Boss.GetEnemyStat().Speed).OnUpdate(() =>
            {
                if (CheckIfPlayerTooClose())
                {
                    moveTween.Kill();
                }
            });

        }
       else
        {
            
                moveTween=   transform.DOMoveX(transform.position.x - 1f, 1 / _Boss.GetEnemyStat().Speed).OnUpdate(() =>
            {
                if (CheckIfPlayerTooClose())
                {
                    moveTween.Kill();
                }
            });

        }
    }
    public void UpdateChaseDir()
    {
        ChaseDir = Player.Instance.transform.position.x - _Boss.transform.position.x;
        if (ChaseDir > 0)
        {
            _Boss.transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {
            _Boss.transform.localScale = new Vector3(1, 1, 1);

        }

    }
   
    public void ApproachingPlayerPos()
    {
       
        transform.DOMoveX(Player.Instance.transform.position.x - Player.Instance.transform.localScale.x * _Boss.GetEnemyStat().AttackRange,.5f);
    }
       
    

    public void AttackCounterReset()
    {
        durationCounter = 0;
    }
    
}
