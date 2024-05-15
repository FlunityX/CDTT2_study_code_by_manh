
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public static class SaveSystem
{
    
    public static void SavePlayer()
    {
        PlayerData data = new PlayerData();

        data.currentscene = Loader.GetCurrentScene();
        data.hp = Player.Instance._playerStat.currentHp;
        data.coin = Player.Instance.coin;
        data.storyItems = PlayerInventory.Instance.storiesItem;
        data.items = PlayerInventory.Instance.items;
        data.buffItems = PlayerInventory.Instance.buffItem;
        data.playerPosX = Player.Instance.checkpointPos.x;
        data.playerPosY = Player.Instance.checkpointPos.y;

        data.status = Player.Instance._statusHolder.statusEffects;

        data.chests = GameManager.Instance.GetChestData();
        string json  = JsonUtility.ToJson(data,true);
         File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
        
        
    }

    public static void LoadNewScene()
    {
        Loader.Load(Loader.Scene.CutScene1);
    }

    public static void SetNewData()
    {
        PlayerData data = new PlayerData();
        //default data of lv1
        data.currentscene = Loader.Scene.GameLevel1.ToString();
        data.hp = 1000;
        data.coin = 0;
        data.storyItems = new List<StoryItemSO> { null,null,null,null};
        data.items = new List<ItemSO>();
        data.buffItems = null;
        data.playerPosX = -40;
        data.playerPosY = 3;
        data.status = new List<StatusEffectSO>();
        data.chests = new List<ChestData> { new ChestData { chest = "WoodenChest", pos=new Vector2(0.06056213f, 22.8072f) },
            new ChestData { chest = "WoodenChest", pos = new Vector2(204.3163f, -44.2428f) },
            new ChestData { chest = "Chest_Empty", pos = new Vector2(407.3769f, 37.4936f) },
            new ChestData { chest = "GoldenChest", pos = new Vector2(431.3849f, -3.588921f) },
            new ChestData { chest = "Chest_Empty", pos = new Vector2(652.83f, -92.55453f) },
            new ChestData { chest = "GoldenChest", pos = new Vector2(691.31f,-100.64f) },
            new ChestData { chest = "DiamondChest", pos = new Vector2(987.83f, 6.559998f) },
            new ChestData { chest = "WoodenChest", pos = new Vector2(1145.37f, 38.86f) },
        };

        
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
    }
    public static void LoadCurrentScene()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/playerData.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Loader.LoadByName(data.currentscene);
        

    }
    public static void LoadData()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/playerData.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        Player.Instance._playerStat.currentHp = data.hp;
        Player.Instance.coin = data.coin;   
        Player.Instance._statusHolder.statusEffects = data.status;
        
        Player.Instance.SpawnOnLastCheckPoint(new Vector2(data.playerPosX +10f,data.playerPosY));
        PlayerInventory.Instance.storiesItem = data.storyItems;
        PlayerInventory.Instance.items = new List<ItemSO>();
        for (int i = 0;i< data.items.Count; i++)
        {
            PlayerInventory.Instance.Add(data.items[i]);    
        }
        PlayerInventory.Instance.Add(data.buffItems);        
        GameManager.Instance.DestroyCurrentChest();
        for (int i = 0; i < data.chests.Count; i++)
        {
            GameManager.Instance.InstantiateNewChest(data.chests[i].chest, data.chests[i].pos);
        }
        Debug.Log("loaded");

    }
   
   public static bool CheckFileExist()
    {
        if(File.Exists(Application.persistentDataPath + "/playerData.json")) return true; return false;
    }
}
