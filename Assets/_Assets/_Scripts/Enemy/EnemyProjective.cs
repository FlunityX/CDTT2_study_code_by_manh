using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjective : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float speed = 20f;
    public float dmg;
    private void Start()
    {
        Vector2 moveDir;
        if (Player.Instance.transform.localScale.x < 0)
        {
            // If the scale is less than 0, the player is facing left
            moveDir = new Vector2(-1, 0);// Move left
        }
        else
        {
            // Otherwise, the player is facing right
            moveDir = Vector2.right; // Move right
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

            }
        }
        //Instantiate(impactEffect, transform.position, transform.rotation);//instantiate effect
        Destroy(gameObject);
    }

    private void DestroyPreb()
    {
        Destroy(gameObject);
    }
}
