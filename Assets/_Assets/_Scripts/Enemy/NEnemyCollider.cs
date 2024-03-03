using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyCollider : MonoBehaviour
{
    [SerializeField] private NormalEnemy _normalEnemy;
   [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private bool isHitObstacle;
    [SerializeField] private bool isHitPlayer;

    private void FixedUpdate()
    {
        DetectObstacle();
        DetectPlayer();
    }
    private void DetectPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward,_normalEnemy.detectRange,_playerLayer);
        if (hit.collider.CompareTag("Player"))
        {
            isHitPlayer = true;
        }
        else
        {
            isHitPlayer= false;
        }
    } 
    private void DetectObstacle()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward,.5f);
        if (hit.collider.CompareTag("Block"))
        {
            isHitObstacle=true;
        }
        else
        {
            isHitObstacle = false;
        }
    }

    public bool CheckIfHitPlayer()
    {
        return isHitPlayer;
    }public bool CheckIfHitObstacle()
    {
        return isHitObstacle;
    }
}
