using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Checkpoint : MonoBehaviour
{
    Player player;
    public GameObject ActivedCheckpoint;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ActivedCheckpoint.activeInHierarchy == false)
            {
                ActivedCheckpoint.SetActive(true);
            }
            // else
            // {
            //     ActivedCheckpoint.SetActive(false);
            // }
            player.UpdateCheckpoint(transform.position);
        }
    }
}