
using UnityEngine;


[CreateAssetMenu()]
public class AttackSpeedBuffAbility : AbilitySO
{
    public override void Activate(GameObject holder)
    {
        base.Activate(holder);
        AttackSpeedUpSO attackSpeedUp = (AttackSpeedUpSO)statusEffectSO;
        attackSpeedUp.OnAttach(holder);
        Debug.Log("attackIncrease");
    }
    public override void Deactivate(GameObject holder)
    {
        base.Deactivate(holder);
        AttackSpeedUpSO attackSpeedUp = (AttackSpeedUpSO)statusEffectSO;
        attackSpeedUp.OnDetach(holder);
    }
}
