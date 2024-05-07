using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
   // public int stage;
   public string currentscene;
    public float hp;
    public float coin;
    public List<ItemSO> items;
    public List<StoryItemSO> storyItems;
    public float playerPosX;
    public float playerPosY;
    public ItemSO buffItems;
    public List<StatusEffectSO> status = new List<StatusEffectSO>();

    public PlayerData()
    {
        currentscene = Loader.GetCurrentScene();   
        hp = Player.Instance._playerStat.currentHp;
        coin = Player.Instance.coin;
         storyItems = PlayerInventory.Instance.storiesItem;
         items = PlayerInventory.Instance.items;
         buffItems = PlayerInventory.Instance.buffItem;
        playerPosX = Player.Instance.checkpointPos.x;
        playerPosY = Player.Instance.checkpointPos.y;
        
         status = Player.Instance._statusHolder.statusEffects;
        

    }
}
