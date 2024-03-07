using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void InteractHandler()
    {
        Debug.Log("Chest loot");
        AnimationAndDestroy();
    }


    public void AnimationAndDestroy()
    {
        animator.CrossFade("chest_1_open", .3f, 0);
        Invoke("DestroyGameObject", 1f);
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    
}
