using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private PlayerInputAction playerInputAction;
    public event EventHandler OnJumpAction;
    private void Awake()
    {
        Instance = this;
        if(playerInputAction == null)
        {
            playerInputAction = new PlayerInputAction();
        }
        playerInputAction.PlayerActionMap.Enable();
        playerInputAction.PlayerActionMap.Jump.performed += Jump_performed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJumpAction?.Invoke(this, EventArgs.Empty);
    }
    public bool JumpPerform()
    {
      return  playerInputAction.PlayerActionMap.Jump.ReadValue<float>() > .4f;
        
    } 
    
    
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.PlayerActionMap.Moving.ReadValue<Vector2>();
        inputVector.Normalize();
        return inputVector;
    }
}
