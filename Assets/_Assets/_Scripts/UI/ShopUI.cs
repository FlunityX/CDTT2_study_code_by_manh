using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUI : ObjectPool
{
    public Transform itemsParent;   
    public GameObject _ShopUI;  
    
    public TextMeshProUGUI playerCoin;
    public List<ItemSO> _itemSO;               
    ShopSlot[] slots; 

   
    public override void Start()
    {
        amountToSpawn = _itemSO.Count-1;
       base.Start();
        // Populate our slots array\
        SpawnShopSlot();
        slots = itemsParent.GetComponentsInChildren<ShopSlot>();
        gameObject.SetActive(false);
    }

  
    public void ShopOpen()
    {
        Show();
        UpdateUI();

    }
 
    private void SpawnShopSlot()
    {
        for (int i = 0; i < _itemSO.Count; i++) {
            GameObject slot = GetObject();
            if(slot != null) { 
                slot.SetActive(true);
            }
        }
    }

    public void RemoveItem(ItemSO itemSo)
    {
        _itemSO.Remove(itemSo);
    }

     public void UpdateUI()
    {
       

        for (int i = 0; i < slots.Length ; i++)
        {
            if (i < _itemSO.Count )  
            {
                slots[i].AddItem(_itemSO[i]);  
            }
            else
            {
                // Otherwise clear the slot
                slots[i].ClearSlot();
            }
        }
        playerCoin.text =Player.Instance.coin.ToString();
        
    }
    public void Show()
    {
        gameObject.SetActive(true);
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
