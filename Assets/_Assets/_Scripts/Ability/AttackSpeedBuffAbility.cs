using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[CreateAssetMenu()]
public class AttackSpeedBuffAbility : AbilitySO
{
    public override void Activate(GameObject holder)
    {
        base.Activate(holder);
        Player.Instance._playerStat.AttackSpeed += Player.Instance._playerStat.AttackSpeed * .2f;
        Debug.Log("attackIncrease");
    }
    public override void Deactivate(GameObject holder)
    {
        base.Deactivate(holder);
        Player.Instance._playerStat.AttackDmg -= Player.Instance._playerStat.AttackSpeed * .2f;
    }
}
