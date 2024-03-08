using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpellAttack : MonoBehaviour,IRangeAttack
{
    private Boss _boss;
    private void Start()
    {
        _boss = GetComponentInParent<Boss>();
    }
    public void RangeAttack()
    {
        _boss.attackCount = 0;
    }

   
}
