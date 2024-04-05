using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjective : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private NormalEnemy normalEnemy;
    private float speed = 20f;
    public float dmg;
    private void Awake()
    {
        normalEnemy = GetComponentInParent<NormalEnemy>();
        dmg = normalEnemy.GetEnemyStat().AttackDmg;
    }
    private void Start()
    {
        Vector2 moveDir;
        if (normalEnemy.transform.localScale.x < 0)
        {
            // If the scale is less than 0, the player is facing left
            moveDir = Vector2.right;// Move left
        }
        else
        {
            // Otherwise, the player is facing right
            moveDir = Vector2.left; // Move right
        }
        rb.velocity = moveDir * speed;
        Invoke("DestroyPreb", 5f);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag(GameConstant.PLAYER_TAG))
            {
                collision.GetComponent<IReceiveDamage>().ReduceHp(dmg);

                Destroy(gameObject);
            }else if(collision.CompareTag(GameConstant.GROUND_TAG))
            {
                Destroy(gameObject);
            }
        }
        //Instantiate(impactEffect, transform.position, transform.rotation);//instantiate effect
    }

    private void DestroyPreb()
    {
        Destroy(gameObject);
    }
}
