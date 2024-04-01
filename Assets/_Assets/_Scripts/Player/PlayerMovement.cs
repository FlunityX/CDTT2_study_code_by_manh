using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _boxRigidbody;
    [SerializeField] public bool isGround = true;
    [SerializeField] public bool isJumping ;
    [SerializeField] public bool isFalling ;
    public bool isReadSlide=true;
    private float jumpTimeCounter;
    private float jumpTime=.1f;
    private float jumpForce = 7f;
    private float slideTimer;
    private float slideTimerMax=3f;

    [SerializeField]private float increasingSpeed = 7f;
    
    public float dirX;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
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
        if (slideTimer < slideTimerMax)
        {
        slideTimer += Time.deltaTime;
           
        }
    }
    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector2 moveDir = new Vector2(inputVector.x, 0);
        dirX = moveDir.x;
        float moveDistance = increasingSpeed * Time.deltaTime;
        //RaycastHit2D hit = Physics2D.Raycast(Player.Instance.transform.position, inputVector);
        // audioManager.PlaySFX(audioManager.walk);


        if (isFalling || isJumping)
        {
            transform.Translate(moveDir * moveDistance/1.25f);
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
           audioManager.PlaySFX(audioManager.jump); 
           _boxRigidbody.velocity = Vector2.up * jumpForce;
            
            
            jumpTimeCounter = jumpTime;
            isGround = false;
            isFalling = false;
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

    
    public void AddingFallForce(float force)
    {
        _boxRigidbody.velocity = Vector2.down * force;
    }
    public void Slide(float force)
    {
        _boxRigidbody.velocity = new Vector2(dirX,-.5f) * force;
        
        if(Player.Instance._playerSlideCollider.isCollideEnemy)
        {
            Physics2D.IgnoreCollision(Player.Instance.Collider, Player.Instance._playerSlideCollider.enemyColider, true);
        }
        else if(!Player.Instance._playerSlideCollider.isCollideEnemy && Player.Instance._playerSlideCollider.enemyColider != null)
        {
            Physics2D.IgnoreCollision(Player.Instance.Collider, Player.Instance._playerSlideCollider.enemyColider, false);

        }
        ResetSlideTimer();
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
        if (increasingSpeed < Player.Instance._playerStat.Speed)
        {
            increasingSpeed += .5f;
        }
        else { increasingSpeed = Player.Instance._playerStat.Speed; }
    }
    private void ForceBoolVariable()
    {
        if (isGround)
        {
            isFalling=false;
            isJumping=false;
        }
    }
    public bool IsReadyToSlide()
    {
        return slideTimer >= slideTimerMax;
    }
    public void ResetIncreasingSpeed()
    {
        increasingSpeed = 7f;
    } 
    public void ResetSlideTimer()
    {
        slideTimer = 0f;
    }

    public void KnockBack()
    {
        _boxRigidbody.velocity = new Vector2(-dirX, .25f) * 15f;
    }

}
