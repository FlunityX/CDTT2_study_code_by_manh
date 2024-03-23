using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private const string PLAYER_PREFS_BIDNINGS = "IOnputBindings";

    private PlayerInputAction playerInputAction;
    public event EventHandler OnJumpAction;
    public event EventHandler OnInteract;
    public event EventHandler OnOpenInventory;
    public event EventHandler OnUseAbility;
    public event EventHandler OnPauseAction;

    public enum Binding
    {
        Attack,
        Jump,
        Slide,
        ActiveItem,
        Move_Left,
        Move_Right,
        Interact,
        Pause,
    }
    private void Awake()
    {
        Instance = this;
        if(playerInputAction == null)
        {
            playerInputAction = new PlayerInputAction();
        }
        if (PlayerPrefs.HasKey(PLAYER_PREFS_BIDNINGS))
        {
            playerInputAction.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_BIDNINGS));
        }
        playerInputAction.PlayerActionMap.Enable();
        playerInputAction.PlayerActionMap.Jump.performed += Jump_performed;
        playerInputAction.PlayerActionMap.Attack.performed += Attack_performed;
        playerInputAction.PlayerActionMap.Interact.performed += Interact_performed;
        playerInputAction.PlayerActionMap.Slide.performed += Slide_performed;
        playerInputAction.PlayerActionMap.OpenInventory.performed += OpenInventory_performed;
        playerInputAction.PlayerActionMap.Nextline.performed += Nextline_performed;
        playerInputAction.PlayerActionMap.UseAbility.performed += UseAbility_performed;
        playerInputAction.PlayerActionMap.Pause.performed += Pause_performed;
        


    }

   

    private void OnDestroy()
    {
        playerInputAction.PlayerActionMap.Jump.performed -= Jump_performed;
        playerInputAction.PlayerActionMap.Attack.performed -= Attack_performed;
        playerInputAction.PlayerActionMap.Interact.performed -= Interact_performed;
        playerInputAction.PlayerActionMap.Slide.performed -= Slide_performed;
        playerInputAction.PlayerActionMap.OpenInventory.performed -= OpenInventory_performed;
        playerInputAction.PlayerActionMap.Nextline.performed -= Nextline_performed;
        playerInputAction.PlayerActionMap.UseAbility.performed -= UseAbility_performed;

        playerInputAction.Dispose();
    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }
    private void UseAbility_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnUseAbility?.Invoke(this, EventArgs.Empty);
    }

    private void Nextline_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        return;
    }

    private void OpenInventory_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOpenInventory?.Invoke(this, EventArgs.Empty);
    }

    private void Slide_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        return;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        return;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpAction?.Invoke(this, EventArgs.Empty);
    }
    public bool JumpPerform()
    {
      return  playerInputAction.PlayerActionMap.Jump.ReadValue<float>() > .4f;
        
    } 
    public float GetJumpValue()
    {
      return  playerInputAction.PlayerActionMap.Jump.ReadValue<float>();
        
    } 
    public void DisableJump()
    {
        playerInputAction.PlayerActionMap.Jump.Disable();
    }
    public void EnableJump()
    {
        playerInputAction.PlayerActionMap.Jump.Enable();
    }

    public bool AttackPerform()
    {
        return playerInputAction.PlayerActionMap.Attack.ReadValue<float>() > .9f;
    }
    public bool SlidePerform()
    {
        return playerInputAction.PlayerActionMap.Slide.ReadValue<float>() > .9f;
    }
    public bool NextLinePerform()
    {
        return playerInputAction.PlayerActionMap.Nextline.ReadValue<float>() > .9f;

    }
    public void DisableGameInput()
    {
        playerInputAction.PlayerActionMap.Disable();

    }
    public void EnableGameInput()
    {
        playerInputAction.PlayerActionMap.Enable();

    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.PlayerActionMap.Move.ReadValue<Vector2>();
        inputVector.Normalize();
        return inputVector;
    }

    public string GetBindingText(Binding binding)
    {
        switch (binding)
        {
            default:
            case Binding.Attack:
                return playerInputAction.PlayerActionMap.Attack.bindings[0].ToDisplayString();


            case Binding.Jump:
                return playerInputAction.PlayerActionMap.Jump.bindings[0].ToDisplayString();


            case Binding.Move_Left:
                return playerInputAction.PlayerActionMap.Move.bindings[1].ToDisplayString();


            case Binding.Move_Right:
                return playerInputAction.PlayerActionMap.Move.bindings[2].ToDisplayString();


            case Binding.Interact:
                return playerInputAction.PlayerActionMap.Interact.bindings[0].ToDisplayString();


            case Binding.ActiveItem:
                return playerInputAction.PlayerActionMap.UseAbility.bindings[0].ToDisplayString();

            case Binding.Slide:
                return playerInputAction.PlayerActionMap.Slide.bindings[0].ToDisplayString();


            case Binding.Pause:
                return playerInputAction.PlayerActionMap.Pause.bindings[0].ToDisplayString();



        }

    }
    public void RebidnBinding(Binding binding, Action onActionRebound)
    {
        playerInputAction.PlayerActionMap.Disable();
        InputAction inputAction;
        int bindingIndex;

        switch (binding)
        {
            default:
            case Binding.Attack:
                inputAction = playerInputAction.PlayerActionMap.Attack;
                bindingIndex = 0;
                break;
            case Binding.Jump:
                inputAction = playerInputAction.PlayerActionMap.Jump;
                bindingIndex = 0;
                break;
            case Binding.Slide:
                inputAction = playerInputAction.PlayerActionMap.Slide;
                bindingIndex = 0;
                break;
            case Binding.ActiveItem:
                inputAction = playerInputAction.PlayerActionMap.UseAbility;
                bindingIndex = 0;
                break;
            case Binding.Move_Left:
                inputAction = playerInputAction.PlayerActionMap.Move;
                bindingIndex = 1;
                break;
            case Binding.Move_Right:
                inputAction = playerInputAction.PlayerActionMap.Move;
                bindingIndex = 2;
                break;
            case Binding.Interact:
                inputAction = playerInputAction.PlayerActionMap.Interact;
                bindingIndex = 0;
                break;
            
            case Binding.Pause:
                inputAction = playerInputAction.PlayerActionMap.Pause;
                bindingIndex = 0;
                break;

        }

        inputAction.PerformInteractiveRebinding(bindingIndex)
         .OnComplete(callback =>
         {
             callback.Dispose();
             playerInputAction.PlayerActionMap.Enable();
             onActionRebound();
             PlayerPrefs.SetString(PLAYER_PREFS_BIDNINGS, playerInputAction.SaveBindingOverridesAsJson());
             PlayerPrefs.Save();
         })
         .Start();
    }
}
