using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp: MonoBehaviour,IInteractable
{
    public ItemSO _item;
   // public Sprite icon;

    public void InteractHandler()
    {
        PickUp();
    }

    public void PickUp() {
        bool wasPickUp = PlayerInventory.Instance.Add(_item);
        if (wasPickUp)
        {
            Destroy(gameObject);
            Debug.Log("Picked up");
        }
    }

}
