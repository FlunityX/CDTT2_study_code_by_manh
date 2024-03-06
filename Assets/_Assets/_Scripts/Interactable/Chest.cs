using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public void InteractHandler()
    {
        Debug.Log("Chest loot");
    }

    
}
