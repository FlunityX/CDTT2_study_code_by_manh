using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IMeleeAttack,IRangeAttack
{
    private float attackSpeed = .5f;
    private float attackCounter;
    public bool isAttackReady;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform airAttackPoint;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject rangeAttackPrefab;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        attackCounter += Time.deltaTime;
    }
    public void MeleeAttack(float dmg)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position,2f,_enemyLayer);
        if(hits != null)
        {
            audioManager.PlaySFX(audioManager.swingSword);
            foreach(Collider2D hit in hits) {
 
                if (hit.CompareTag("Enemy"))
                {
                    audioManager.PlaySFX(audioManager.hit);
                    hit.GetComponent<IReceiveDamage>().ReduceHp(dmg);
                } 
            }
        }
        ResetAttackCounter();
    }
    public void PlayerAirAttack(float dmg)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(airAttackPoint.position, new Vector3(8, 2, 0), 0);
        if (hits != null)
        {
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Enemy"))
                {
                    hit.GetComponent<IReceiveDamage>().ReduceHp(dmg);
                }
            }
        }
        ResetAttackCounter();
    }
   public bool IsAttackingReady() {
        return attackCounter >= attackSpeed;
    }
    public void ResetAttackCounter()
    {
        attackCounter = 0;
    }

    public void RangeAttack()
    {
        Instantiate(rangeAttackPrefab, attackPoint.position, transform.rotation);
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
       // Gizmos.DrawCube(airAttackPoint.position, new Vector3(8,2,0));
    }
}
