using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image icon;          // Reference to the Icon image
    public Button buyButton; // Reference to the remove button
    public TextMeshProUGUI itemInfoText;
    ItemSO item;  // Current item in the slot


    // Add item to the slot
    public void AddItem(ItemSO newItem)
    {
        item = newItem;

        icon.sprite = item.Icon;
        icon.enabled = true;
        buyButton.image.enabled = true;
        buyButton.interactable = true;
    }

    
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        buyButton.image.enabled = false;
        buyButton.interactable = false;
    }


    public void ShowItemInfo()
    {
        itemInfoText.text = item.ItemInfo;
        itemInfoText.enabled = true;
    }
    // Called when the remove button is pressed
    public void OnBuyButton()
    {
        PlayerInventory.Instance.Add(item);
        Player.Instance.coin -= item.Price;
    }

  
}
