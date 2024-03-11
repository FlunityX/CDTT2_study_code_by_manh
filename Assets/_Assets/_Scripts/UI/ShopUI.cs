using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour, IInteractable
{
    public Transform itemsParent;   
    public GameObject _ShopUI;  
    PlayerInventory inventory;
    public TextMeshProUGUI playerCoin;
    public ItemSO[] _itemSO;               
    ItemSlot[] slots; 

    void Start()
    {
        inventory = PlayerInventory.Instance;
        // Populate our slots array
        slots = itemsParent.GetComponentsInChildren<ItemSlot>();
        gameObject.SetActive(false);
    }

  
    public void ShopOpen()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        UpdateUI();

    }
 



    void UpdateUI()
    {
        
        for (int i = 0; i < slots.Length - 1; i++)
        {
            if (i < inventory.items.Count && inventory.items[i].IsConsumable)  
            {
                slots[i].AddItem(_itemSO[i]);  
            }
            else
            {
                // Otherwise clear the slot
                slots[i].ClearSlot();
            }
        }

        
    }

    public void InteractHandler()
    {
        ShopOpen();
    }
}
