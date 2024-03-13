using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask _playerLayer;
   public void DealDmg()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(5, 18), 0);
        if(hits != null)
        {
            foreach(Collider2D hit in hits)
            {
                Debug.Log(hit.gameObject.name);

                if (hit.CompareTag(GameConstant.PLAYER_TAG)){
                    hit.gameObject.GetComponent<IReceiveDamage>().ReduceHp(1f);

                }
            }
        }
        else
        {
            return;
        }
       
    }

   public void DestroySpell()
    {
        Destroy(gameObject);
    }
}
