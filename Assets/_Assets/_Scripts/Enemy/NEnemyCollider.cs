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
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Transform playerCheckPoint;

    private void Update()
    {
        DetectObstacle();
        DetectPlayer();
        
    }
    private void DetectPlayer()
    {
        Collider2D hit;
       hit= Physics2D.OverlapBox(playerCheckPoint.position, new Vector2(4, .5f), 0);
        if (hit.GetComponent<Collider>() != null)
        {

            if (hit.GetComponent<Collider>().CompareTag("Player"))
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
        Collider2D hit;
        hit = Physics2D.OverlapBox(playerCheckPoint.position, new Vector2(.5f, .5f), 0);
        if (hit != null)
        {
            if (hit.CompareTag("Ground"))
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(playerCheckPoint.position, new Vector2(4, .5f));
    }
}
