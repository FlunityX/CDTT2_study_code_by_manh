using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy :MonoBehaviour, INormalEnemy, IDealDamage, IReceiveDamage
{
    [SerializeField]private EnemyStat _enemyStat;
    [SerializeField]private EnemyMeleeAttack _enemyMeleeAttack;
    [SerializeField]private NEnemyCollider _enemyCollider;
    [SerializeField] private Rigidbody2D _rb;
    public float detectRange = 4f; // player vao tam nay se bi phat hien

    public NEnemyCollider GetNEnemyCollider() { return _enemyCollider; }
    public EnemyMeleeAttack GetNEnemyAttack() { return _enemyMeleeAttack; }
    public EnemyStat GetEnemyStat() { return _enemyStat;}
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
        _enemyStat.Hp -= dmg;
    }
}
