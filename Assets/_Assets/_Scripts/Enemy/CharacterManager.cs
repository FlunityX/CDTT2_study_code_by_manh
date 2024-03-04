using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    protected bool _isFacingRight = false;
    protected Rigidbody2D _rb;

    public bool GetIsFacingRight() { return _isFacingRight; }

    public Rigidbody2D GetRigidbody2D() { return _rb; }

    [SerializeField]protected CharacterBaseState _state;



    protected virtual void GetReferenceComponents()
    {
       
        _rb = GetComponent<Rigidbody2D>();
    }

 

    protected virtual void Update()
    {
        _state?.Update();
    }

 

 
    public virtual void ChangeState(CharacterBaseState state)
    {
        _state.ExitState();
        _state = state;
        _state.EnterState(this);
    }

    public void FlippingSprite()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, 180, 0);
        //Hàm này dùng để lật sprite theo chiều ngang
        //Debug.Log("vao day");
    }
}
