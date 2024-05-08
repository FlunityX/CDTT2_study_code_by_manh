
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        for (int i = 0; i < GameManager.Instance.chestHolder.transform.childCount; i++)
        {
            ChestData chestData = new ChestData();
            chestData.chest = GameManager.Instance.chestHolder.transform.GetChild(i).GetComponent<Chest>().chestSO;
            chestData.pos = GameManager.Instance.chestHolder.transform.GetChild(i).transform.position;
            data.chests.Add(chestData);


        }
        string json  = JsonUtility.ToJson(data,true);
         File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
        DebugData();
        
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
        Player.Instance.checkpointPos.x = data.playerPosX;
        Player.Instance.checkpointPos.y = data.playerPosY;
        PlayerInventory.Instance.storiesItem = data.storyItems;
        PlayerInventory.Instance.items = data.items;    
        PlayerInventory.Instance.buffItem = data.buffItems;
        GameManager.Instance.DestroyCurrentChest();
        for (int i = 0; i < data.chests.Count; i++)
        {
            GameManager.Instance.InstantiateNewChest(data.chests[i].chest, data.chests[i].pos);
        }
        Debug.Log("loaded");

    }
   
    public static void DebugData()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/playerData.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
 
        Debug.Log(data.hp);
        Debug.Log(data.currentscene);
    }
}
