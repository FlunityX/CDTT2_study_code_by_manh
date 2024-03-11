using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SpeedBuffAbility : AbilitySO
{
    public override void Activate()
    {
        base.Activate();
        Player.Instance.Speed += 10f;
        Debug.Log("Speed Up");
    }
    public override void Deactivate()
    {
        base.Deactivate();
        Player.Instance.Speed -= 10f;
    }
}
