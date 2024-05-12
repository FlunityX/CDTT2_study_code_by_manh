using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Checkpoint : MonoBehaviour
{
    
    public GameObject ActivedCheckpoint;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ActivedCheckpoint.activeInHierarchy == false)
            {
                ActivedCheckpoint.SetActive(true);
            }

            collision.GetComponent<Player>().LastCheckPoint();
            Player.Instance.SaveData();
        }
    }
}