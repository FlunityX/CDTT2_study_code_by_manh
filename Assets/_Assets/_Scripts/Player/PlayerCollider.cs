using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    [SerializeField] private BoxCollider2D _groundCollider;
    [SerializeField] private LayerMask _ItemLayer;
    [SerializeField] private LayerMask _GroundLayer;
    public bool wall;


    private void Update()
    {
        WallCheck();
    }
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
    public void WallCheck()
    {
        RaycastHit2D wallCheck = Physics2D.BoxCast(transform.position, new Vector2(.5f, 5), 0f, new Vector2(Player.Instance.transform.localScale.x, 0), 1f, _GroundLayer);
        if(wallCheck.collider == null)
        {
            wall = false;
        }
        else
        {
            wall = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector2(2,4));
    }
}
