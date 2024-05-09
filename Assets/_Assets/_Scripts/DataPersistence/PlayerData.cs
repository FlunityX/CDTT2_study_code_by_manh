using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
   // public int stage;
   public string currentscene;
    public float hp;
    public float coin;
    public List<ItemSO> items=new List<ItemSO>();
    public List<StoryItemSO> storyItems = new List<StoryItemSO>();
    public float playerPosX;
    public float playerPosY;
    public ItemSO buffItems;
    public List<StatusEffectSO> status = new List<StatusEffectSO>();
    public List<ChestData> chests = new List<ChestData>();

  
}
    
