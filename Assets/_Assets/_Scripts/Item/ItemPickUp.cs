using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp: MonoBehaviour,IInteractable
{
    public ItemSO _item;
    public GameObject interactUI;
    public SpriteRenderer sprite;
    private void Start()
    {
        interactUI.SetActive(false);
        sprite.sprite = _item.Icon;
    }
    public void InteractHandler()
    {
        PickUp();
    }

    public void PickUp() {
        bool wasPickUp = PlayerInventory.Instance.Add(_item);
        if (wasPickUp)
        {
            Destroy(gameObject);
        }
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
