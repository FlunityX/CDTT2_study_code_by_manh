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
        UnitStat target = holder.GetComponent<UnitStat>();
        if(target != null){
            target.AttackDmg += amount;
        }

        
    }
    public override void OnDetach(GameObject holder)
    {
        base.OnDetach(holder);
        UnitStat target = holder.GetComponent<UnitStat>();
        if (target != null)
        {
            target.AttackDmg -= amount;
        }

    }
}
