using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyCollider : MonoBehaviour
{
    [SerializeField] private NormalEnemy _normalEnemy;
    [SerializeField] private BoxCollider2D _checkPlayerCollider;
    [SerializeField] private bool isHitObstacle=false;
    [SerializeField] private bool isHitPlayer=false;
    [SerializeField] private Transform groundCheckPoint;

    private void Start()
    {
        _checkPlayerCollider= gameObject.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        DetectObstacle();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHitPlayer = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHitPlayer = false;
        }
        
    }
    private void DetectObstacle()
    {
        Collider2D hit;
        hit = Physics2D.OverlapBox(groundCheckPoint.position, new Vector2(.5f, .5f),0);
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
            return;
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
