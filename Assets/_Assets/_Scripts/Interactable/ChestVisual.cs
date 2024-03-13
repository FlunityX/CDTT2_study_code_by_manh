using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestVisual : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void AnimationAndDestroy()
    {
        animator.CrossFade("chest_1_open", .3f, 0);
        
    }

}
