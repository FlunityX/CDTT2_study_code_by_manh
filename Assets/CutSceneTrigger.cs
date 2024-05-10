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
            Player.Instance._playerMovement.canMove = false;
            Invoke("DestroyTimeLineTrigger", 5f);
        }
        
    }
    private void OnDestroy()
    {
        mainCamera.SetActive(true);
        cutsceneCamera.SetActive(false);
        Player.Instance._playerMovement.canMove = true;

        cutsceneDirector.Stop();
    }
    private void DestroyTimeLineTrigger()
    {
        Destroy(gameObject);
    }

}