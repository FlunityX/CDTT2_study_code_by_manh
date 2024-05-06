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
    public bool isRunning= false;
    public bool canMove= true;
    public bool canJump= true;
    public bool canContJump;
    public bool jumpperform;
    public float jumpHeight=3f;
    [SerializeField] private float jumpTimeCounter;
    [SerializeField] private float jumpTime=.3f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float slideDistance = 20f;
    [SerializeField] private float slideTimerMax=5f;
    [SerializeField]private float slideTimer;
    [SerializeField]private float increasingSpeed = 5f;
    [SerializeField] private Transform slideRaycastPoint;
    public Vector3 moveDir;
    public LayerMask groundLayer;
    private Tween moveTween;
    private Tween jumpTween;
    private Tween ConjumpTween;
    private Tween slideTween;
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
      
    }

    private void FixedUpdate()
    { 
        if(canMove)
        {
            HandleMovement();
        }
        FlipPlayerSprite();
        IncreasSpeed();
        DashColliderCheck();
       ContinueJump();
        if (slideTimer <= slideTimerMax)
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
            isRunning = false;

            if (!Player.Instance._playerCollider.wallCollider)
            {
                moveTween = transform.DOMoveX(transform.position.x + moveDir.x, moveDuration *2)
                    .OnUpdate(() =>
                    {
                        
                        if (Player.Instance._playerCollider.wallCollider)
                        {
                            moveTween.Kill();

                        }
                    });
            }
        }
        else if(!Player.Instance._playerCollider.wallCollider && moveDir.x!=0)
        {
            isRunning = true;

            moveTween = transform.DOMoveX(transform.position.x + moveDir.x, moveDuration)
                 .OnUpdate(() =>
                 {


                     if (Player.Instance._playerCollider.wallCollider)
                     {
                         moveTween.Kill();

                     }
                 });

        }
        isRunning = false;

        // Debug.Log(moveDir);
    }

    public void Jump()
    {
       
        isJumping = true;
        canJump = false;
        jumpTween = transform.DOMoveY(transform.position.y + jumpHeight,.3f)
            
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    isFalling = true;
                    isJumping = false;
                    canJump = true;
                    
                })
                .OnUpdate(() =>
                {
                    if (Player.Instance._playerCollider.ceilCollider)
                    {
                        jumpTween.Kill();
                        isFalling = true;
                        isJumping = false;
                        isRunning = false;
                    }
                    

                })
                ;

           
            isGround = false;
        
    }
   
 
  
    public void ContinueJump()
    {
        if (isJumping && GameInput.Instance.JumpPerform() )
        {
            
            jumpTween.Kill() ;
            ConjumpTween = transform.DOMoveY(transform.position.y + 3f, .3f)
                .OnUpdate(() =>
                {
                    if (Player.Instance._playerCollider.ceilCollider)
                    {
                        ConjumpTween.Kill();
                        isFalling = true;
                        isJumping = false;
                        isRunning = false;
                    }


            })
            .OnComplete(() =>
             {
                 
                 isFalling = true;
                 isJumping = false;
                 canJump = true;
                 if (GameInput.Instance.JumpCancle()){
                     ConjumpTween.Kill() ;
                 }

             });
           



        }




    }

  
    public bool DashColliderCheck()
    {
        RaycastHit2D slide = Physics2D.Raycast(slideRaycastPoint.position, new Vector2(Player.Instance.transform.localScale.x, 0), 4f, groundLayer);
        if (slide.collider == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Dash()
    {
        slideTween = transform.DOMove(new Vector3(transform.position.x + transform.localScale.x * slideDistance, transform.position.y, 0), .5f)
            .OnUpdate(() =>
            {
                RaycastHit2D slideHit = Physics2D.Raycast(slideRaycastPoint.position, new Vector2(Player.Instance.transform.localScale.x, 0), 2f, groundLayer);
                if (slideHit.collider != null)
                {
                    slideTween.Kill();
                }
                    
                    jumpTween.Kill();
                    moveTween.Kill();
            })
            ;
            
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
  
    public bool IsReadyToSlide()
    {
        return slideTimer >= slideTimerMax ;
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
