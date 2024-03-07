using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    [SerializeField] private BoxCollider2D _groundCollider;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _ItemLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

           Player.Instance._playerMovement.isGround = true;
            Player.Instance._playerMovement.isJumping = false;
            Player.Instance._playerMovement.isFalling = false;

        }


    }
    public bool AirAttackGroundCheck()
    {
        Collider2D hit = Physics2D.OverlapBox(_groundCheckPoint.position, new Vector2(.5f, .5f), 0);
        if (hit.CompareTag(GameConstant.GROUND_TAG))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void InteractableCollider()
    {

        Collider2D hit = Physics2D.OverlapCircle(transform.position,4f,_ItemLayer);
        if (hit.CompareTag(GameConstant.INTERACTABLE_TAG))
        {
            hit.GetComponent<IInteractable>().InteractHandler();
        }
       
    }

}
