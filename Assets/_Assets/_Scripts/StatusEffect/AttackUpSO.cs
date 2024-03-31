using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AttackUpSO : StatusEffectSO
{
    public float amount;
    public override void OnAttach(GameObject holder)
    {
        base.OnAttach(holder);
        holder.GetComponent<UnitStat>().AttackDmg += amount;
    }
    public override void OnDetach(GameObject holder)
    {
        base.OnDetach(holder);
        holder.GetComponent<UnitStat>().AttackDmg -= amount;

    }
}
