using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatusEffectSO : ScriptableObject
{
   
    public virtual void OnAttach(GameObject holder) { }
    public virtual void OnDetach(GameObject holder) { }
}
