using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    [SerializeField] public List<ItemSO> items = new List<ItemSO>();
    [SerializeField] public List<StoryItemSO> storiesItem = new List<StoryItemSO>();
    [SerializeField] public ItemSO buffItem;
    [SerializeField]private int space = 9;
    public event EventHandler OnItemChanged;
    public event EventHandler OnBuffItemChange;

    private void Awake()
    {
        Instance = this;
    }
    public bool Add(ItemSO item)
    {
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
                Player.Instance.SetStatusEffect();
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
            storiesItem.Add(story);
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
            Player.Instance.RemoveEffect();
            OnItemChanged?.Invoke(this, EventArgs.Empty);
            OnBuffItemChange?.Invoke(this, EventArgs.Empty);

            }

        }
    }

    public StatusEffectSO GetStatusEffect()
    {

        BuffItemSO buffItemSO = (BuffItemSO)buffItem;
        if (buffItemSO._abilitySO.passiveEffect != null)
        {
        return buffItemSO._abilitySO.passiveEffect;

        }
        return null;
    }
    public void DropItem(ItemSO item)
    {
       GameObject drop = GameManager.Instance.resourceManager.DropItem;
        drop.GetComponent<ItemPickUp>()._item = item;
        Instantiate(drop, Player.Instance._dropItemPoint.position, Quaternion.identity);
        Debug.Log("drop");
       
    }
   
}
