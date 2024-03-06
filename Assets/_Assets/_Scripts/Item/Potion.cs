using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item, IConsumable
{
    public void OnConsume()
    {
        Debug.Log("used");
    }

}
