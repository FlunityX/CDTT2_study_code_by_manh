using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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


    public bool _isFacingLeft;
    public bool _isFacingRight;
    public int attackCount;
    public bool isGetHit;


    public event EventHandler<IHasHpBar.OnHpChangeEventArgs> OnHpChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(IReceiveDamage receiveDmg, float dmg)
    {
        receiveDmg.ReduceHp(dmg);
    }

    public void ReduceHp(float dmg)
    {
        _enemyStat.currentHp -= dmg;
        isGetHit = true;
        OnHpChange?.Invoke(this, new IHasHpBar.OnHpChangeEventArgs
        {
            HpNormalized = _enemyStat.currentHp / _enemyStat.Hp
        }); ; ;


    }
}
