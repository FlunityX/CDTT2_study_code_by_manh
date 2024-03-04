using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D _boxCollider;
    [SerializeField] public Rigidbody2D _boxRigidbody;
    [SerializeField]public bool isGround = true;
    [SerializeField] public bool isJumping ;
    [SerializeField] public bool isFalling ;
    private float jumpTimeCounter;
    private float jumpTime=.5f;
    private float jumpForce = 6f;
    private float increasingSpeed = 5f;
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
        FlipPlayerSprite();
        IncreasSpeed();
        ForceBoolVariable();
    }
    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector2 moveDir = new Vector2(inputVector.x, 0);
        dirX = moveDir.x;
        float moveDistance = increasingSpeed * Time.deltaTime;
        //RaycastHit2D hit = Physics2D.Raycast(Player.Instance.transform.position, inputVector);


        if (isFalling || isJumping)
        {
            transform.Translate(moveDir * moveDistance/2);
        }
        else
        {
            transform.Translate(moveDir * moveDistance);

        }
       // Debug.Log(moveDir);
    }

    private void Jump()
    {
        if(isGround)
        {
           
           _boxRigidbody.velocity = Vector2.up * jumpForce;
            
            
            jumpTimeCounter = jumpTime;
            isGround = false;
            isFalling=false;
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
            isFalling = true;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            isGround = true;
            isJumping= false;
            isFalling= false;
            
        }

        
    }
    public void AddingFallForce(float force)
    {
        _boxRigidbody.velocity = Vector2.down * force;
    }
    private void FlipPlayerSprite()
    {
        if(dirX >0)
        {
            transform.localScale = Vector3.one;
        }else if(dirX < 0)
        {
            transform.localScale =new Vector3(-1,1,1);
        }
        else
        {
            return;
        }
    }
    private void IncreasSpeed()
    {
        if (increasingSpeed < Player.Instance.Speed)
        {
            increasingSpeed += .5f;
        }
        else { increasingSpeed = Player.Instance.Speed; }
    }
    private void ForceBoolVariable()
    {
        if (isGround)
        {
            isFalling=false;
            isJumping=false;
        }
    }
    public void RestIncreasingSpeed()
    {
        increasingSpeed = 5f;
    }
}
