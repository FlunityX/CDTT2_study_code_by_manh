using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideCollider : MonoBehaviour
{
    public bool isCollideEnemy = false;
    public Collider2D enemyColider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {

            if (collision.gameObject.CompareTag(GameConstant.ENEMY_TAG))
            {
                enemyColider = collision;
                isCollideEnemy = true;

            }
        }
        else return;


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {

            if (collision.gameObject.CompareTag(GameConstant.ENEMY_TAG))
            {
                enemyColider = collision;
                isCollideEnemy = false;

            }
        }
        else return;
    }
}
