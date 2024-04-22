using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    
    [SerializeField] private LayerMask _ItemLayer;
    [SerializeField] private LayerMask _GroundLayer;
    public bool wallCollider;
    public Vector3 wallColliderPos;
    public bool ceilCollider;
    public bool ishitGround;
    public float ceilheigh;

    private void LateUpdate()
    {
        WallCheck();
        GroundCheck();
        CeilCheck();
     
    }
    

    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 3.1f,_GroundLayer);
        if(hit.collider != null)
        {
            Player.Instance._playerMovement.isGround = true;
            ishitGround = true;
        }
        else
        {
            Player.Instance._playerMovement.isGround = false;
            ishitGround = false;

        }
    }
    private void CeilCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position,new  Vector2(2f,.5f),0,Vector2.up, ceilheigh,_GroundLayer);
        if(hit.collider != null)
        {
            ceilCollider = true;
        }
        else
        {
            ceilCollider = false;

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
        RaycastHit2D wallCheck = Physics2D.BoxCast(transform.position, new Vector2(1.1f, 5.5f), 0f, new Vector2(Player.Instance.transform.localScale.x, 0), 1.2f, _GroundLayer);
        if(wallCheck.collider == null)
        {
            wallCollider = false;

            wallColliderPos = Vector2.zero;
        }
        else
        {
            wallColliderPos = wallCheck.point;
            wallCollider = true;
        }
    }
    public void ImmuteAttack()
    {
        Physics2D.IgnoreLayerCollision(10,13, true);
    }
    public void UnimmuteAttack()
    {
        Physics2D.IgnoreLayerCollision(10, 13, false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector2(3.2f,5.5f));
    }
}
