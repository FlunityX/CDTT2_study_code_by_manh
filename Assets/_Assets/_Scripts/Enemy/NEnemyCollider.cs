using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyCollider : MonoBehaviour
{
    [SerializeField] private NormalEnemy _normalEnemy;
   [SerializeField] private LayerMask _playerLayer;
   [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private bool isHitObstacle=false;
    [SerializeField] private bool isHitPlayer=false;

    private void Update()
    {
        DetectObstacle();
        DetectPlayer();
        
    }
    private void DetectPlayer()
    {
        RaycastHit2D hit;
        if (transform.localScale== Vector3.one)
        {
         hit = Physics2D.Raycast(transform.position,new Vector2(1,0),4f,_playerLayer);

        }
        else
        {
             hit= Physics2D.Raycast(transform.position, new Vector2(-1, 0), 4f, _playerLayer);

        }
        if (hit.collider != null)
        {

            if (hit.collider.CompareTag("Player"))
            {
                isHitPlayer = true;
                //Debug.Log(isHitPlayer);
            }
        }
        else
        {

                isHitPlayer= false;
        }
            
            
    }
    private void DetectObstacle()
    {
        RaycastHit2D hit;
        if (transform.localScale == Vector3.one)
        {
            hit = Physics2D.Raycast(transform.position, new Vector2(1, 0), 1f, _groundLayer);

        }
        else
        {
            hit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 1f, _groundLayer);

        }
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Ground"))
            {
                isHitObstacle = true;
               // Debug.Log("hitground");

            }

        }
        else
        {

                isHitObstacle = false;
        }
            
    }

    public bool CheckIfHitPlayer()
    {
        return isHitPlayer;
    }
    public bool CheckIfHitObstacle()
    {
        return isHitObstacle;
    }
}
