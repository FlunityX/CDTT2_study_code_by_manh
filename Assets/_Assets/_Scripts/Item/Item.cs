using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item: MonoBehaviour 
{
    public Item _item;
    public Sprite icon;

    public virtual void PickUp() { }

}
