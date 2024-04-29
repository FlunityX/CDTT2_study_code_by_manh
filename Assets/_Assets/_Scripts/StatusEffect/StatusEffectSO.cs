using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatusEffectSO : ScriptableObject
{
    public Sprite icon;
    public float duration;
    public float counter;
    public bool firstCall;
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
