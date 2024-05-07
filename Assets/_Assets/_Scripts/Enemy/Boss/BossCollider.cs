using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] public bool isPlayerInRange ;
    [SerializeField] public bool isPlayerInAttackRange ;
    public bool isPlayerTooClose;
    [SerializeField] private LayerMask _playerLayer;

    private void Update()
    {
        PlayerColliderCheck();
        IsPlayerInAttackRange();
        IsPlayerTooClose();
    }

    private void PlayerColliderCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(-_boss.transform.localScale.x,0),_boss.GetEnemyStat().AttackRange*2,_playerLayer);
        if(hit.collider == null)
        {
            isPlayerInRange = false;
        }
        else
        {
            isPlayerInRange = true;
        }
    }

    private void IsPlayerInAttackRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(-_boss.transform.localScale.x, 0), _boss.GetEnemyStat().AttackRange, _playerLayer);
        if (hit.collider == null)
        {
            isPlayerInAttackRange= false;
        }
        else
        {
           isPlayerInAttackRange= true;
        }
    }
    private void IsPlayerTooClose()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position,new Vector2(10,12),0,Vector2.right,0,_playerLayer);
        if(hit.collider != null)
        {
            isPlayerTooClose= true;
        }else isPlayerTooClose = false;
    }
   
}
