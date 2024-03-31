using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SpeedBuffAbility : AbilitySO
{
    public override void Activate(GameObject holder)
    {
        base.Activate(holder);
        Player.Instance._playerStat.Speed += 10f;
        Debug.Log("Speed Up");
    }
    public override void Deactivate(GameObject holder)
    {
        base.Deactivate(holder);
        Player.Instance._playerStat.Speed -= 10f;
    }
}
