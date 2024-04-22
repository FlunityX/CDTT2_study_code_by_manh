using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] public bool isPlayerInRange ;
    [SerializeField] public bool isPlayerInAttackRange ;
    [SerializeField] private LayerMask _playerLayer;

    private void Update()
    {
        PlayerColliderCheck();
        IsPlayerInAttackRange();
    }

    private void PlayerColliderCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(_boss.GetDirX(),0),_boss.GetEnemyStat().AttackRange*2,_playerLayer);
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(_boss.GetDirX(), 0), _boss.GetEnemyStat().AttackRange, _playerLayer);
        if (hit.collider == null)
        {
            isPlayerInAttackRange= false;
        }
        else
        {
           isPlayerInAttackRange= true;
        }
    }
    public void ImmuteAttack()
    {
        Physics2D.IgnoreLayerCollision(11,12,true);
    }
    public void UnimmuteAttack()
    {
        Physics2D.IgnoreLayerCollision(11,12,false);
    }
}
