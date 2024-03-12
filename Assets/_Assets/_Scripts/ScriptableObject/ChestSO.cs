using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class ChestSO : ScriptableObject
{
    public Sprite chestSprite;
    public string chestName;
    public ItemSO[] itemSOs;
    public int coinAmount;
}
