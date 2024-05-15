using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteract : MonoBehaviour
{
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private BoxCollider2D interactBox;

    private void Awake()
    {
        tutorialUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstant.PLAYER_TAG))
        {
            tutorialUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstant.PLAYER_TAG))
        {
            tutorialUI.SetActive(false);
            Destroy(tutorialUI);
            Destroy(gameObject); 
        }
    }
}
