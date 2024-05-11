
using Sirenix.OdinInspector;
using System;
using UnityEngine;


public class StatusEffectSO : SerializedScriptableObject
{
    public Sprite icon;
    public float duration;
    public float counter;
    public bool firstCall;
    public bool isOverTime;
    public virtual void OnAttach(GameObject holder) { }
    public virtual void OnDetach(GameObject holder) {
        ResetValue();
    }
    public virtual void ResetValue()
    {
        counter = 0;
        firstCall = true;
    }
}
