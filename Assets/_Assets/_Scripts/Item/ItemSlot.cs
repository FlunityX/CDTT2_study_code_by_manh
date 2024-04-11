using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;          // Reference to the Icon image
    public Button removeButton; // Reference to the remove button
    public Transform itemDes;
    public TextMeshProUGUI itemDesTxt;
    ItemSO item;  // Current item in the slot

    private void Start()
    {
        itemDesHide();
    }

    // Add item to the slot
    public void AddItem(ItemSO newItem)
    {
        item = newItem;

        icon.sprite = item.Icon;
        icon.enabled = true;
        removeButton.image.enabled = true;
        removeButton.interactable = true;
        itemDesTxt.text = item.ItemInfo;

    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.image.enabled = false;
        removeButton.interactable = false;
    }

    // Called when the remove button is pressed
    public void OnRemoveButton()
    {
        PlayerInventory.Instance.Remove(item);
    }

    // Called when the item is pressed
    public void UseItem()
    {
        if (item != null && Player.Instance.canUsePotion)
        {
            PotionSO potionSO = (PotionSO)item;
            potionSO.OnConsume();
            PlayerInventory.Instance.Remove(item);
            Debug.Log("consume");
          
        }
    }
    public void itemDesShow()
    {
       if(item!=null) itemDes.gameObject.SetActive(true);
    }
    public void itemDesHide()
    {
        
        itemDes.gameObject.SetActive(false);
    }

}
