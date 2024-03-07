using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

// using System.Numerics;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializationField] public float dmg;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<IReceiveDamage>().ReduceHp(dmg);
        }
    }

  

}

internal class SerializationFieldAttribute : Attribute
{
}