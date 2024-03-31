using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public AbilitySO _abilitySO;
    public float coolDown;
    public float duration;
    public bool IsUsed;
    public bool IsActive=false;
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
        if (_abilitySO !=null)
        {
        OnUsedAbility();
            
        }
    }

    private void Update()
    {
        abilityStateUpdate();
        
    }
    private void abilityStateUpdate()
    {
        switch (state)
        {
            case abilityState.ready:
                
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
                if(duration >= _abilitySO.duration)
                {

                    state = abilityState.coolDown;
                    IsUsed = false;
                    Debug.Log("to cool");
                    DurationReset();
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
                if(coolDown >= _abilitySO.coolDown)
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
