using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DamageOverTimeSO : StatusEffectSO
{
    public float dmg;
    public float dmgCounter;

    public override void OnAttach(GameObject holder)
    {
        base.OnAttach(holder);
            if(dmgCounter > 1)
            {
                holder.GetComponent<IReceiveDamage>().ReduceHp(dmg);
                dmgCounter = 0;
                Debug.Log("ajjdhahsjdhadkashdjasjkd");
            }
            else
            {
                
            dmgCounter += Time.deltaTime;
            }
            
    }

    public override void OnDetach(GameObject holder)
    {
        base.OnDetach(holder);
    }
  
}
