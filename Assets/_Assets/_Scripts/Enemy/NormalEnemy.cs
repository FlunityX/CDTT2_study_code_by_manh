using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy :MonoBehaviour, INormalEnemy, IDealDamage, IReceiveDamage
{
    [SerializeField]private EnemyStat _enemyStat;
    [SerializeField]private EnemyMeleeAttack _enemyMeleeAttack;
    public void DealDamage(IReceiveDamage receiveDmg, float dmg)
    {
        receiveDmg.ReduceHp(dmg);
    }

    public void ReduceHp(float dmg)
    {
        _enemyStat.Hp -= dmg;
    }
}
