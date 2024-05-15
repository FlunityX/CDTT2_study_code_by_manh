using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

     public List<ItemSO> items = new List<ItemSO>();
     public List<StoryItemSO> storiesItem = new List<StoryItemSO> {null, null,null };
     public ItemSO buffItem;
    [SerializeField]private int space = 9;
    public event EventHandler OnItemChanged;
    public event EventHandler OnBuffItemChange;

    private void Awake()
    {
        Instance = this;
    }
    public bool Add(ItemSO item)
    {
        if (item == null) return false;
        if (item.ItemType ==1)
        {
            if (items.Count <= space)
            {
                items.Add(item);
                OnItemChanged?.Invoke(this, EventArgs.Empty);
                return true;

            }
            else
            {
                NotificationUI.Instance.Show(GameConstant.INVENTORY_FULL_TEXT);

                return false;
            }
        }
        else if (item.ItemType ==2) 
        {
            if(buffItem == null)
            {
                buffItem=item;
                OnItemChanged?.Invoke(this, EventArgs.Empty);
                
                return true;
            }
            else
            {
                NotificationUI.Instance.Show(GameConstant.INVENTORY_BUFF_ITEM_TEXT);
                return false;
            }
        }else
        {
           StoryItemSO story = (StoryItemSO)item;
            storiesItem[story.index] = story;
            return true;
        }
    }
   
    public void Remove(ItemSO item)
    {
        if(item.ItemType == 1)
        {
            DropItem(item);
            items.Remove(item);
            OnItemChanged?.Invoke(this, EventArgs.Empty);

        }
        else if(item.ItemType == 2) 
        {
            BuffItemSO _buffItem = (BuffItemSO)buffItem;
            if (!_buffItem._abilitySO.isActive)
            {
            DropItem(item);
            buffItem = null;
            
               Player.Instance.RemoveAbility();
            OnItemChanged?.Invoke(this, EventArgs.Empty);
            OnBuffItemChange?.Invoke(this, EventArgs.Empty);

            }

        }
    }

    public void RemoveOnUse(ItemSO itemSO)
    {
        items.Remove(itemSO);
        OnItemChanged?.Invoke(this, EventArgs.Empty);
    }
    
    public void DropItem(ItemSO item)
    {
       GameObject drop = GameManager.Instance.resourceManager.DropItem;
        drop.GetComponent<ItemPickUp>()._item = item;
        Instantiate(drop, Player.Instance._dropItemPoint.position, Quaternion.identity);
        
        Debug.Log("drop");
       
    }
   
}
