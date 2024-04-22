using UnityEngine;
using DG.Tweening;
public class BossManager : CharacterManager
{
    public Boss _Boss;
    
    public BossIdleState _IdleState = new();
    public BossWalkState _WalkState = new();
    public BossMeleeAttackState _MeleeAttack =new();
    public BossCastSpellState _CastSpellState = new();
    public BossHurtState _HurtState = new();
    public BossDeathState _DeathState = new();

    public float attackDuration = .5f;
    public float spellDuration = 5f;
    public float getHitDuration = .2f;
    public float hiddingDuration = 5f;
    public float durationCounter;
    public float ChaseDir;

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
    public bool CheckIfCanAttackHidding()
    {
        return durationCounter > hiddingDuration && _Boss.GetBossMeleeAttack().IsReadyToAttack();
    }
    public bool IsPlayerInAttackRange()
    {
        return _Boss.GetBossCollider().isPlayerInAttackRange;
    }

    public void Chase()
    {
        if (ChaseDir > 0)
        {
            _Boss.transform.Translate(Vector2.right * _Boss.GetEnemyStat().Speed  * Time.deltaTime);
        }
        else
        {
            _Boss.transform.Translate(Vector2.left * _Boss.GetEnemyStat().Speed  * Time.deltaTime);

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
