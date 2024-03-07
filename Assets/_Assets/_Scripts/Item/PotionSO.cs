using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu()]

public class PotionSO : ItemSO, IConsumable
{


    public void OnConsume()
    {
        Debug.Log("used");
    }

    



}
