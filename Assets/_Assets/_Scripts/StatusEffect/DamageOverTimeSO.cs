using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DamageOverTimeSO : StatusEffectSO
{
    public float dmg;
    private float dmgCounter;

    public override void OnAttach(GameObject holder)
    {
        base.OnAttach(holder);
        if(dmgCounter < 1)
        {
            dmgCounter += Time.deltaTime;
        }else
        {
            holder.GetComponent<IReceiveDamage>().ReduceHp(dmg);
            dmgCounter = 0;
        }

    }

    public override void OnDetach(GameObject holder)
    {
        base.OnDetach(holder);
    }
}
