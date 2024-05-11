using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TrapSO : ScriptableObject
{
    public string trapName;
    public float dmg;
    public StatusEffectSO effect;
}
