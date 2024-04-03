using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;

public class StatusEffectHolder : MonoBehaviour
{
    private List<StatusEffectSO> statusEffects;
    private float counter;
    enum statusState{
        inactive,
        active
    }
    statusState state = statusState.inactive;
    private void Start()
    {
        statusEffects = new List<StatusEffectSO>();
    }
    private void Update()
    {
        if (statusEffects != null)
        {      
            foreach ( StatusEffectSO status in  statusEffects )
            {
                UpdateStatus(status);
            }
        }
    }
    public void AddEffect(StatusEffectSO effect)
    {
        statusEffects.Add(effect);
    }
    public void RemoveEffect(StatusEffectSO effect) { 
        statusEffects.Remove(effect);
    }

    private void UpdateStatus(StatusEffectSO status)
    {
        switch(state){
            case statusState.inactive:
                state = statusState.active; break;
            case statusState.active:
                if(status.duration < counter)
                {
                    counter += Time.deltaTime;
                }
                state = statusState.inactive;
                RemoveEffect(status);
                break;
        }
    }
}
