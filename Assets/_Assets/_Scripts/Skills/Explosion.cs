using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    
    public void DealDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(gameObject.transform.position, 8f);
        foreach(Collider2D hit in hits)
        {
            if(hit.CompareTag(GameConstant.ENEMY_TAG))
            {
                hit.GetComponent<IReceiveDamage>().ReduceHp(999);
            }

        }
    }
    public void PlaySound()
    {
        GameManager.Instance.soundManager.PlayExplosionSound(transform.position);
    }
    public void DestroyPrefab()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
    
}
