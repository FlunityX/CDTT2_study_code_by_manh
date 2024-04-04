using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    [SerializeField] private BoxCollider2D _groundCollider;
    [SerializeField] private LayerMask _ItemLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.GROUND_TAG))
        {

           Player.Instance._playerMovement.isGround = true;
            Player.Instance._playerMovement.isJumping = false;
            Player.Instance._playerMovement.isFalling = false;

        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.GROUND_TAG))
        {

            Player.Instance._playerMovement.isGround = false;
            

        }
    }
  
    public void InteractableCollider()
    {

        Collider2D hit = Physics2D.OverlapCircle(transform.position,4f,_ItemLayer);
        if (hit == null) {
            return;
        }
        else
        {

        if (hit.CompareTag(GameConstant.INTERACTABLE_TAG))
        {
            hit.GetComponent<IInteractable>().InteractHandler();
        }
        }
       
    }

}
