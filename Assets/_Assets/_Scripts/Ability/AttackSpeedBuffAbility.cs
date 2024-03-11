using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AttackSpeedBuffAbility : AbilitySO
{
    public override void Activate()
    {
        base.Activate();
        Player.Instance._playerAttack.attackSpeed += Player.Instance._playerAttack.attackSpeed*.2f;
        Debug.Log("attackIncrease");
    }
    public override void Deactivate()
    {
        base.Deactivate();
        Player.Instance.Dmg -= Player.Instance._playerAttack.attackSpeed * .2f;
    }
}
