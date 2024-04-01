using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    [SerializeField] public float dmg;

    
    [Header("Spike Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    // private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            collision.GetComponent<IReceiveDamage>().ReduceHp(dmg);
            collision.GetComponent<Player>()._playerMovement.KnockBack();
        }
    }


}
