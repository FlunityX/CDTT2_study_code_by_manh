using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySO : ScriptableObject
{
    public string AbilityName;
    public float coolDown;
    public float duration;
    public bool isActive;
    public StatusEffectSO statusEffectSO;
    public StatusEffectSO passiveEffect;

    public virtual void Activate(GameObject holder) { }

    public virtual void Deactivate(GameObject holder) { }
}
