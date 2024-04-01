using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SpeedUpSO : StatusEffectSO
{
    public float amount;
    public override void OnAttach(GameObject holder)
    {
        base.OnAttach(holder);
        UnitStat target = holder.GetComponent<UnitStat>();
        if (target != null)
        {
            target.Speed += amount;
        }


    }
    public override void OnDetach(GameObject holder)
    {
        base.OnDetach(holder);
        holder.GetComponent<UnitStat>().Speed -= amount;

    }
}
