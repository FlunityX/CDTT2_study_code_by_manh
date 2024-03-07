using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    [SerializeField] public List<ItemSO> items = new List<ItemSO>();
    [SerializeField]private int space = 9;
    public event EventHandler OnItemChanged;

    private void Awake()
    {
        Instance = this;
    }
    public bool Add(ItemSO item)
    {
        if(items.Count <= space)
        {
            items.Add(item);
            OnItemChanged?.Invoke(this, EventArgs.Empty);
            return true;

        }
        else {
            Debug.Log("Inventory full");
            return false; 
        }
    }public void Remove(ItemSO item)
    {

        items.Remove(item);
        OnItemChanged?.Invoke(this, EventArgs.Empty);
    }
}
