using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _rigidbody;
    [SerializeField] public bool isGround ;
    [SerializeField] public bool isJumping ;
    [SerializeField] public bool isFalling ;
    [SerializeField] public bool canIdleFall ;
    public bool isReadySlide=true;
    private float jumpTimeCounter;
    private float jumpTime=.2f;
    private float jumpForce = 20f;
    public bool isRunning= false;
    [SerializeField]private float slideTimer;
    private float slideTimerMax=5f;
    public Vector3 moveDir;
    public LayerMask groundLayer;
    [SerializeField]private float increasingSpeed = 5f;
    private Tween moveTween;
    private Tween jumpTween;
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
        //Jump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
   
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
        
        if (isFalling || isJumping)
        {
            if (!Player.Instance._playerCollider.wallCollider)
            {
                moveTween = transform.DOMoveX(transform.position.x + moveDir.x, moveDuration *2)
                    .OnUpdate(() =>
                    {
                        
                        isRunning = false; 
                        if (Player.Instance._playerCollider.wallCollider)
                        {
                            moveTween.Kill();

                        }
                    });
            }
        }
        else if(!Player.Instance._playerCollider.wallCollider)
        {
           
           moveTween =  transform.DOMoveX(transform.position.x + moveDir.x,moveDuration)
                .OnUpdate(() =>
                {
                    if (moveDir.x != 0) {
                        isRunning = true;
                    }
                    if (Player.Instance._playerCollider.wallCollider)
                    {
                        moveTween.Kill();

                    }
                });

        }
       // Debug.Log(moveDir);
    }

    public void Jump()
    {
       
        isJumping = true;

        jumpTween = transform.DOMoveY(transform.position.y + 5f,.5f)
            
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    isFalling = true;
                    isJumping= false;
                })
                .OnUpdate(() =>
                {
                    if (Player.Instance._playerCollider.ceilCollider)
                    {
                        jumpTween.Kill();
                        isFalling = true; isJumping = false;
                    }

                })
                ;

           
            isGround = false;
        
    }
   
    public void InteruptAirMovement()
    {
        jumpTween.Kill();
    }
    public void InteruptMovement()
    {
        moveTween.Pause();
    } 
    public void notInteruptMovement()
    {
        moveTween.Play();
    }
    private void ContinueJump()
    {
        if (isJumping && GameInput.Instance.JumpPerform() && !Player.Instance._playerMovement.isGround)
        {
            if (jumpTimeCounter > 0)
            {
                _rigidbody.velocity =  Vector2.up * jumpForce/2;
                
                jumpTimeCounter -= Time.deltaTime;
                isGround = false; 
                isJumping = true;
            }
            
        } 
    }
    
    private void FallCheck()
    {
       if(_rigidbody.velocity.y <0)
        {
            isJumping = false;
            isFalling = true;
            
        }
    }

    
    public void AddingFallForce(float force)
    {
        _rigidbody.velocity = Vector2.down * force ;
    }
    public void Slide(float force)
    {
        _rigidbody.velocity = new Vector2(dirX,-.5f) * force;
        
        
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
        _rigidbody.velocity = new Vector2(-dirX, .25f) * 15f;
    }

}
