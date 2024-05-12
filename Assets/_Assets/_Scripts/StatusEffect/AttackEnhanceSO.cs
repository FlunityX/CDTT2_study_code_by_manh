using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AttackEnhanceSO : StatusEffectSO
{
    public override void OnAttach(GameObject holder)
    {
        base.OnAttach(holder);
        Player.Instance.OnPlayerAttack += Instance_OnPlayerAttack;


    }

    private void Instance_OnPlayerAttack(object sender, System.EventArgs e)
    {
        Instantiate(GameManager.Instance.resourceManager.Slash,Player.Instance._playerAttack.attackPoint.position,Quaternion.identity);
    }

    public override void OnDetach(GameObject holder)
    {
        base.OnDetach(holder);
        
    }
}
