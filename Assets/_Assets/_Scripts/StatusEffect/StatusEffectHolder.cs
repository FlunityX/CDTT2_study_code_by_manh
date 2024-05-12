using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StatusEffectHolder : MonoBehaviour
{
    public List<StatusEffectSO> statusEffects = new List<StatusEffectSO>();
    public StatusEffectSO staaaa;

    public event EventHandler onStatusChange;
    enum statusState{
        inactive,
        active
    }
    statusState state = statusState.inactive;
    
    private void Update()
    {
        if (statusEffects !=null)
        {  
           
            for(int i = 0; i < statusEffects.Count; i++) {
                if (statusEffects[i].isTemp) {
                
                    UpdateStatus(statusEffects[i]);
                }
                else
                {
                    statusEffects[i].OnAttach(gameObject);
                }
            }
        }
    }
    public void AddEffect(StatusEffectSO effect)
    {
        StatusEffectSO instance = Instantiate(effect);// create an instance of the effect pass to function -> all the same effect can work independence
        statusEffects.Add(instance);
        onStatusChange?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveEffect(StatusEffectSO effect) { 
        statusEffects.Remove(effect);
        onStatusChange?.Invoke(this, EventArgs.Empty);

    }
    public void DirectAdd()
    {
        AddEffect(staaaa);
    }
    private void UpdateStatus(StatusEffectSO status)
    {
        
        switch(state){
            case statusState.inactive:
                
                state = statusState.active; 
                break;
            case statusState.active:
                if(status.duration > status.counter)
                {
                    status.counter += Time.deltaTime;
                    if (status.firstCall && !status.isOverTime)
                    {
                        status.OnAttach(gameObject);
                        Debug.Log("it work");
                        status.firstCall = false;
                    }
                    else if(status.isOverTime)
                    {
                        status.OnAttach(gameObject);
                    }
                }
                else
                {
                    status.OnDetach(gameObject);
                    state = statusState.inactive;
                    RemoveEffect(status);
                }

                break;
        }
    }
}
