using System;

using UnityEngine;

public class Boss : MonoBehaviour, IReceiveDamage, IDealDamage, IHasHpBar
{
    [SerializeField]private BossCollider _bossCollider;
    [SerializeField] private BossMeleeAttack _meleeAttack;
    [SerializeField] private BossSpellAttack _spellAttack;
  
    [SerializeField] private BossVisual _bossVisual;
    [SerializeField] private EnemyStat _enemyStat;
    public BossCollider GetBossCollider() { return _bossCollider; }
    public BossMeleeAttack GetBossMeleeAttack() { return _meleeAttack; }
    public BossSpellAttack GetBossSpellAttack() { return _spellAttack; }
    
    public BossVisual GetBossVisual() { return _bossVisual; }
    public EnemyStat GetEnemyStat() { return _enemyStat; }

    public float counter;
    public float timer = 20f;
    public bool isDead;

    public int attackCount;
    public bool isGetHit;
    public bool canUseHidding;

    public event EventHandler<IHasHpBar.OnHpChangeEventArgs> OnHpChange;

    private void Update()
    {
        counter += Time.deltaTime;
        if(counter > timer)
        {
            canUseHidding = true;
            counter = 0;
        }
    }

    public void DealDamage(IReceiveDamage receiveDmg, float dmg)
    {
        receiveDmg.ReduceHp(dmg);
    }

    public void ReduceHp(float dmg)
    {
        _enemyStat.currentHp -= dmg * (1 - _enemyStat.Defense/100);
        isGetHit = true;
        OnHpChange?.Invoke(this, new IHasHpBar.OnHpChangeEventArgs
        {
            HpNormalized = _enemyStat.currentHp / _enemyStat.Hp
        }); ; ;
        if(_enemyStat.currentHp < _enemyStat.Hp/2) {
            canUseHidding = true;
        }
        if(_enemyStat.currentHp <= 0)
        {
            isDead = true;
        }


    }

    public float GetDirX()
    {
        return transform.localScale.x;
    }

    public void ImmuteAttack()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
    public void UnimmuteAttack()
    {
        gameObject.layer = LayerMask.NameToLayer(GameConstant.ENEMY_TAG);

    }
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
