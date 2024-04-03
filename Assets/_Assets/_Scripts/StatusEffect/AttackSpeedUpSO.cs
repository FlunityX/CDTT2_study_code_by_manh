using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AttackSpeedUpSO : StatusEffectSO
{
    public float amount;
    public override void OnAttach(GameObject holder)
    {
        base.OnAttach(holder);
        UnitStat target = holder.GetComponent<UnitStat>();
        if (target != null)
        {
            target.AttackSpeed -= (amount / 100) * target.AttackSpeed;
        }


    }
    public override void OnDetach(GameObject holder)
    {
        base.OnDetach(holder);
        holder.GetComponent<UnitStat>().AttackSpeed += (amount / (100-amount)) * holder.GetComponent<UnitStat>().AttackSpeed;

    }
}
