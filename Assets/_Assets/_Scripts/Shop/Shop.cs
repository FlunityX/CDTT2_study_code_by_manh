using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    [SerializeField] private ShopUI shopUI;

    public void InteractHandler()
    {
        shopUI.ShopOpen();
    }
    
}
