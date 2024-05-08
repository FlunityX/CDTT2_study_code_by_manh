using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
     public ChestSO chestSO;
    [SerializeField] private ChestVisual _chestVisual;
    public GameObject interactUI;

    private void Start()
    {
     _chestVisual = GetComponentInChildren<ChestVisual>();
        _chestVisual.chestSprite.sprite = chestSO.chestSprite;
     
    }
    public void InteractHandler()
    {
        Debug.Log("Chest_Diamond loot");
        ChestLoot();
        _chestVisual.ChestOpenAnim(chestSO.chestName);
        Invoke("DestroyGameObject", 1f);
    }


   
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    public void ChestLoot()
    {
        int rand = Random.Range(0, 3);
        PlayerInventory.Instance.Add(chestSO.itemSOs[rand]);
        Player.Instance.coin += chestSO.coinAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstant.PLAYER_TAG))
        {
            interactUI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstant.PLAYER_TAG))
        {
            interactUI.SetActive(false);
        }
    }
}
