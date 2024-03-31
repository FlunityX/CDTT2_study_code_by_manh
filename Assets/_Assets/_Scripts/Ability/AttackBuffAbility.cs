using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu()]

public class AttackBuffAbility : AbilitySO
{

    public override void Activate(GameObject holder)
    {
        base.Activate(holder);
       AttackUpSO attack= (AttackUpSO)statusEffectSO;
        attack.OnAttach(holder);
        Debug.Log("attackIncrease");
    }
    public override void Deactivate(GameObject holder)
    {
        base.Deactivate(holder);
        AttackUpSO attack = (AttackUpSO)statusEffectSO;
        attack.OnDetach(holder);
    }
}
