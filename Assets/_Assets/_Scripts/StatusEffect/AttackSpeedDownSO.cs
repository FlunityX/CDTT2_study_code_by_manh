using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AttackSpeedDownSO : StatusEffectSO
{
    public float amount;
    public override void OnAttach(GameObject holder)
    {
        base.OnAttach(holder);
        UnitStat target = holder.GetComponent<UnitStat>();
        if (target != null)
        {
            target.AttackSpeed += (amount/100) * target.AttackSpeed;
        }


    }
    public override void OnDetach(GameObject holder)
    {
        base.OnDetach(holder);
        UnitStat target = holder.GetComponent<UnitStat>();
        if (target != null)
        {
            target.AttackSpeed -= (amount / 100) * holder.GetComponent<UnitStat>()._unitSO.AttackSpeed.GetValue(); ;
        }
        

    }
}
