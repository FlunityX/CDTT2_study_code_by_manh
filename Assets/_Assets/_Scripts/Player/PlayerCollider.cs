using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D _boxCollider;
    [SerializeField] private Transform _groundCheckPoint;

    private void OnCollisionEnter2D(Collision2D collision)
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

}
