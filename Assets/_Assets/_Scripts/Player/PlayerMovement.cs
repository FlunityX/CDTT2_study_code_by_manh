using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _boxRigidbody;
    [SerializeField] public bool isGround ;
    [SerializeField] public bool isJumping ;
    [SerializeField] public bool isFalling ;
    public bool isReadySlide=true;
    private float jumpTimeCounter;
    private float jumpTime=.2f;
    private float jumpForce = 20f;
    [SerializeField]private float slideTimer;
    private float slideTimerMax=5f;
    public Vector3 moveDir;
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
         moveDir = new Vector3(inputVector.x, 0,0);
        dirX = moveDir.x;
        float moveDistance = increasingSpeed * Time.deltaTime;
        //RaycastHit2D hit = Physics2D.Raycast(Player.Instance.transform.position, inputVector);
        // audioManager.PlaySFX(audioManager.walk);
        float moveDuration = 1 / Player.Instance._playerStat.Speed;
        if (Player.Instance._playerCollider.wall)
       {
            moveDir = Vector3.zero;
        }
        if (isFalling || isJumping)
        {
            transform.DOMove(transform.position + moveDir, moveDuration/1.5f);
        }
        else
        {
           // transform.Translate(moveDir * moveDistance);
            transform.DOMove(transform.position + moveDir,moveDuration);

        }
       // Debug.Log(moveDir);
    }

    private void Jump()
    {
       //if(isGround)
        {
            // audioManager.PlaySFX(audioManager.jump); 
            // Sequence jumpNrun = DOTween.Sequence();
            //jumpNrun.Append(transform.DOMoveY(transform.position.y + jumpForce, .5f)).Append(transform.DOMove(transform.position + moveDir, 1f));
            transform.DOJump(transform.position + new Vector3(0,100,0), 100f, 2, 2f);
            //_boxRigidbody.velocity = Vector2.up * jumpForce;



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
                _boxRigidbody.velocity =  Vector2.up * jumpForce/2;
                
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
        _boxRigidbody.velocity = Vector2.down * force ;
    }
    public void Slide(float force)
    {
        _boxRigidbody.velocity = new Vector2(dirX,-.5f) * force;
        
        
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
