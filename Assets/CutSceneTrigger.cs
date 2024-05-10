using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] public PlayableDirector cutsceneDirector;
    public GameObject cutsceneCamera;
    public GameObject mainCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            mainCamera.SetActive(false);
            cutsceneCamera.SetActive(true);
            cutsceneDirector.Play();
            GetComponent<BoxCollider2D>().enabled = false; 
        }
        mainCamera.SetActive(true);
    }
}