using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    [SerializeField] public List<ItemSO> items = new List<ItemSO>();
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
        if (item.IsConsumable)
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
        else
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
        }
    }public void Remove(ItemSO item)
    {
        if(item.IsConsumable)
        {
            items.Remove(item);
            OnItemChanged?.Invoke(this, EventArgs.Empty);

        }
        else
        {
            buffItem = null;
            OnItemChanged?.Invoke(this, EventArgs.Empty);
            OnBuffItemChange?.Invoke(this, EventArgs.Empty);

        }
    }
}
