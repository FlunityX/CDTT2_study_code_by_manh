using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    [SerializeField] public List<Item> items = new List<Item>();
    [SerializeField]private int space = 10;
    public event EventHandler OnItemChanged;

    private void Awake()
    {
        Instance = this;
    }
    public bool Add(Item item)
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
    }public void Remove(Item item)
    {
        OnItemChanged?.Invoke(this, EventArgs.Empty);

        items.Remove(item);
    }
}
