using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SpeedBuffAbility : AbilitySO
{
    public override void Activate(GameObject holder)
    {
        base.Activate(holder);
        SpeedUpSO speedUp = (SpeedUpSO)statusEffectSO;
        speedUp.OnAttach(holder);
        Debug.Log("Speed Up");
    }
    public override void Deactivate(GameObject holder)
    {
        base.Deactivate(holder);
        SpeedUpSO speedUp = (SpeedUpSO)statusEffectSO;
        speedUp.OnAttach(holder);
    }
}
