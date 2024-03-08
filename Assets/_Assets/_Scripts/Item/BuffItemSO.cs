using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BuffItemSO : ItemSO, INonConsumable
{
    public AbilitySO _abilitySO;

  

    public void OnEquip()
    {
        Player.Instance._abilityHolder._abilitySO = _abilitySO;
        Debug.Log("eqiup");
    }
}
