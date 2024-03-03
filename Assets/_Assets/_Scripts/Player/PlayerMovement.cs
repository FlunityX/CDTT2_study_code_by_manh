using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] public Rigidbody2D _boxRigidbody;
    [SerializeField]public bool isGround = true;
    [SerializeField] public bool isJumping ;
    private float jumpTimeCounter;
    private float jumpTime=.5f;
    private float jumpForce = 3f;
    public float dirX;
    private void Start()
    {
        GameInput.Instance.OnJumpAction += GameInput_OnJumpAction;
    }

    private void GameInput_OnJumpAction(object sender, System.EventArgs e)
    {
        Jump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        FallCheck();
       ContinueJump();

    }
    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector2 moveDir = new Vector2(inputVector.x, 0);
        dirX = moveDir.x;
        float moveDistance = Player.Instance.Speed * Time.deltaTime;
        //RaycastHit2D hit = Physics2D.Raycast(Player.Instance.transform.position, inputVector);
      
        

        transform.Translate(moveDir * moveDistance);
        Debug.Log(moveDir);
    }

    private void Jump()
    {
        if(isGround)
        {
           
           _boxRigidbody.velocity = Vector2.up * jumpForce;
            
            
            jumpTimeCounter = jumpTime;
            isGround = false;
           isJumping = true;

        }
        
        
    }
    private void ContinueJump()
    {
        if (isJumping && GameInput.Instance.JumpPerform() && !Player.Instance._playerMovement.isGround)
        {
            if (jumpTimeCounter > 0)
            {
                _boxRigidbody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                isGround = false;
                isJumping = true;
            }
            
        }
    }
    private void FallCheck()
    {
       if(_boxRigidbody.velocity.y <0)
        {
            isJumping = false;
        }
    }
    public void IncreaseGravity()
    {
        _boxRigidbody.gravityScale += 1f * Time.deltaTime;
    }
    public void ResetGravity()
    {
        _boxRigidbody.gravityScale = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            isGround = true;
            isJumping= false;
            
        }
        
    }
}
