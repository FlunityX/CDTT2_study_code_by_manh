using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator animator;
    [SerializeField]private PotionSO[] potionSO ;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void InteractHandler()
    {
        Debug.Log("Chest loot");
        ChestLoot();
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
    public void ChestLoot()
    {
        int rand = Random.Range(0, 3);
        PlayerInventory.Instance.Add(potionSO[rand]);
        Player.Instance.coin += Random.Range(10, 50);
    }
}
