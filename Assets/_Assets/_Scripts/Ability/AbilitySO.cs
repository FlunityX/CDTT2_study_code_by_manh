using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySO : ScriptableObject
{
    public string AbilityName;
    public float coolDown;
    public float duration;
    public StatusEffectSO statusEffectSO = null;

    public virtual void Activate(GameObject holder) { }

    public virtual void Deactivate(GameObject holder) { }
}
