using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemSO : ScriptableObject
{
    public int ItemType;//type 1:consumable, type 2: nonconsumable, type3: story item
    public string ItemName;
    public Sprite Icon;
    public float Price;
    public string ItemInfo;

 

   
}
