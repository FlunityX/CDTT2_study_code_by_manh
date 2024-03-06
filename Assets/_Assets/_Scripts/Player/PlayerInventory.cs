using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance {  get; private set; }
    
    [SerializeField]private List<ItemSO> items = new List<ItemSO>();
    [SerializeField]private int space = 10;


    private void Awake()
    {
        Instance = this;
    }
    public bool Add(ItemSO item)
    {
        if(items.Count <= space)
        {
            items.Add(item);
            return true;

        }
        else {
            Debug.Log("Inventory full");
            return false; 
        }
    }public void Remove(ItemSO item)
    {
        items.Remove(item);
    }
}
