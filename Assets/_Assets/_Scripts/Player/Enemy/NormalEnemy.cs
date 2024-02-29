using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : INormalEnemy, IDealDamage, IReceiveDamage
{
    private EnemyStat _enemyStat;
    public void DealDamage(IReceiveDamage receiveDmg, float dmg)
    {
        receiveDmg.ReduceHp(dmg);
    }

    public void ReduceHp(float dmg)
    {
        _enemyStat.Hp -= dmg;
    }
}
