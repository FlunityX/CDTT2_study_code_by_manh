using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]

public class AttackBuffAbility : AbilitySO
{

    public override void Activate()
    {
        base.Activate();
        Player.Instance.Dmg += 10f;
        Debug.Log("attackIncrease");
    }
    public override void Deactivate()
    {
        base.Deactivate();
        Player.Instance.Dmg -= 10f;
    }
}
