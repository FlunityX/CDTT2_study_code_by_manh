using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;   // The parent object of all the items
    //public GameObject inventoryUI;  // The entire UI
       
   // public Transform BuffHolder;
    ItemSlot[] slots;  // List of all the slots

    void Start()
    {
        
        PlayerInventory.Instance.OnItemChanged += Inventory_OnItemChanged;    
        GameInput.Instance.OnOpenInventory += GameInput_OnOpenInventory;
        // Populate our slots array
        slots = itemsParent.GetComponentsInChildren<ItemSlot>();
        gameObject.SetActive(false);
    }

    private void GameInput_OnOpenInventory(object sender, System.EventArgs e)
    {
        if (gameObject.activeInHierarchy)
        {
            Hide();
        }else Show();
    }

    private void Inventory_OnItemChanged(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

  

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    void UpdateUI()
    {
        // Loop through all the slots
        for (int i = 0; i < slots.Length-1; i++)
        {
            if (i < PlayerInventory.Instance.items.Count && PlayerInventory.Instance.items[i].ItemType ==1)  // If there is an item to add
            {
                slots[i].AddItem(PlayerInventory.Instance.items[i]);   // Add it
            }
            else
            {
                // Otherwise clear the slot
                slots[i].ClearSlot();
            }
        }
        
            if (PlayerInventory.Instance.buffItem!=null) {
                slots[9].AddItem(PlayerInventory.Instance.buffItem);
                BuffItemSO buff = (BuffItemSO)PlayerInventory.Instance.buffItem;
                buff.OnEquip();
            }
            else
            {
                slots[9].ClearSlot();
            }
        }

    public void Show()
    {
        UpdateUI();
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
        
    }
 

