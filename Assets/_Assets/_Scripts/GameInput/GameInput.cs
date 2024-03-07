using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private PlayerInputAction playerInputAction;
    public event EventHandler OnJumpAction;
    public event EventHandler OnInteract;
    public event EventHandler OnOpenInventory;
    private void Awake()
    {
        Instance = this;
        if(playerInputAction == null)
        {
            playerInputAction = new PlayerInputAction();
        }
        playerInputAction.PlayerActionMap.Enable();
        playerInputAction.PlayerActionMap.Jump.performed += Jump_performed;
        playerInputAction.PlayerActionMap.Attack.performed += Attack_performed;
        playerInputAction.PlayerActionMap.Interact.performed += Interact_performed;
        playerInputAction.PlayerActionMap.Slide.performed += Slide_performed;
        playerInputAction.PlayerActionMap.OpenInventory.performed += OpenInventory_performed;
        
 
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

    public bool AttackPerform()
    {
        return playerInputAction.PlayerActionMap.Attack.ReadValue<float>() > .9f;
    }
    public bool SlidePerform()
    {
        return playerInputAction.PlayerActionMap.Slide.ReadValue<float>() > .9f;
    }


    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.PlayerActionMap.Move.ReadValue<Vector2>();
        inputVector.Normalize();
        return inputVector;
    }
}
