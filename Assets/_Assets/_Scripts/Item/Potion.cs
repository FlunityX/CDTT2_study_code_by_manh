using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item, IConsumable,IInteractable
{
    public void InteractHandler()
    {
        PickUp();
    }

    public void OnConsume()
    {
        Debug.Log("used");
    }

    public override void PickUp()
    {
        base.PickUp();
        bool wasPickUp= PlayerInventory.Instance.Add(_itemSO);
        if(wasPickUp)
        {
            Destroy(gameObject);
            Debug.Log("Picked up");
        }
    }

}
