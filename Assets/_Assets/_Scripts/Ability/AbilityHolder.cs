using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public AbilitySO _abilitySO;
    public float coolDown;
    public float duration;
    public bool IsUsed;
    public bool IsActive=false;
    public bool IsCalled = false;
    enum abilityState
    {
        ready,
        active,
        coolDown
    }
    abilityState state = abilityState.ready;

    private void Start()
    {
        GameInput.Instance.OnUseAbility += GameInput_OnUseAbility;
        PlayerInventory.Instance.OnBuffItemChange += PlayerInventory_OnBuffItemChange;
        if(_abilitySO != null)
        {
         _abilitySO.GetDuration(); 
        }

    }

    private void PlayerInventory_OnBuffItemChange(object sender, System.EventArgs e)
    {
        
        BuffItemSO abilitySO = (BuffItemSO)PlayerInventory.Instance.buffItem;
        if(abilitySO != null ) {
            _abilitySO = abilitySO._abilitySO;
        }
        else
        {
            _abilitySO = null;

        }
    }

    private void GameInput_OnUseAbility(object sender, System.EventArgs e)
    {
        if (_abilitySO !=null && state==abilityState.ready)
        {
            OnUsedAbility();
            
        }
    }

    private void Update()
    {
        if (_abilitySO != null)
        {
            abilityStateUpdate();

        }
        
    }
    private void abilityStateUpdate()
    {
        switch (state)
        {
            case abilityState.ready:
                _abilitySO.isActive = false;

                if (IsUsed)
                {
                    Debug.Log("runiing");
                    state = abilityState.active;
                    IsActive = false;
                }
                break;

            case abilityState.active:
                Debug.Log("usung");
                duration += Time.deltaTime;
                _abilitySO.isActive = true;
                if(_abilitySO.statusEffectSO != null && !IsCalled)
                {
                    IsCalled = true;
                    _abilitySO.statusEffectSO.OnAttach(Player.Instance.gameObject);
                }
                if(duration >= _abilitySO.duration)
                {

                    state = abilityState.coolDown;
                    IsUsed = false;
                    Debug.Log("to cool");
                    DurationReset();
                    _abilitySO.statusEffectSO.OnDetach(Player.Instance.gameObject);
                    _abilitySO.Deactivate(Player.Instance.gameObject);

                }
                else
                {
                    if (!IsActive)
                    {
                        _abilitySO.Activate(Player.Instance.gameObject);
                        IsActive = true;
                    }
                }

                break; 
            case abilityState.coolDown:
                Debug.Log("end");
                coolDown += Time.deltaTime;
                _abilitySO.isActive = false;
                IsCalled = false;
                if (coolDown >= _abilitySO.coolDown)
                {
                    state = abilityState.ready;
                    CoolDownReset();
                }
                break;
        }
    }
    private void CoolDownReset()
    {
        coolDown = 0;
    }
    private void DurationReset()
    {
        duration = 0;
    }

    public void OnUsedAbility()
    {
        IsUsed= true;
    }
}
