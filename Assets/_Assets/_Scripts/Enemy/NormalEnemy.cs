using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy :MonoBehaviour, IDealDamage, IReceiveDamage
{
    [SerializeField]private EnemyStat _enemyStat;
    [SerializeField]private EnemyAttack _enemyAttack;
    [SerializeField]private NEnemyCollider _enemyCollider;
    [SerializeField]private NEnemyVisual _enemyVisual;
    [SerializeField] private Rigidbody2D _rb;
    public float detectRange = 4f; // player vao tam nay se bi phat hien
    public bool isGetHit;

    public bool _isFacingRight { get;set; }
    public bool _isFacingLeft { get; set; }
    public NEnemyCollider GetNEnemyCollider() { return _enemyCollider; }
    public EnemyAttack GetNEnemyAttack() { return _enemyAttack; }
    public EnemyStat GetEnemyStat() { return _enemyStat;}
    public NEnemyVisual GetEnemyVisual() { return _enemyVisual;}
    public Rigidbody2D GetRigidBody()
    {
        return _rb;
    }
    public void DealDamage(IReceiveDamage receiveDmg, float dmg)
    {
        receiveDmg.ReduceHp(dmg);
    }

    public void ReduceHp(float dmg)
    {
        _enemyStat.currentHp -= dmg * (1 - _enemyStat.Defense/100);
        isGetHit = true;
    }
}
