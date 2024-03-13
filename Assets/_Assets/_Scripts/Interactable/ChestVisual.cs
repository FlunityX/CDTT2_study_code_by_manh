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
    public void ChestOpenAnim(string chestName)
    {
        animator.CrossFade(chestName, .2f, 0);
        
    }

}
