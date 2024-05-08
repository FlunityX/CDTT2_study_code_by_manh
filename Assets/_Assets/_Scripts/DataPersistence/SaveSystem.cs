
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    public static void SavePlayer()
    {
        PlayerData data = new PlayerData(); 
        string json  = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/playerData.json", json);
        Debug.Log("saved");
        
    }
    public static void LoadCurrentScene()
    {
        string json = File.ReadAllText(Application.dataPath + "/playerData.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Loader.LoadByName(data.currentscene);

    }
    public static void LoadData()
    {
        string json = File.ReadAllText(Application.dataPath + "/playerData.json");
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
    public static bool CheckFileExist()
    {
       if( File.Exists(Application.dataPath + "/playerData.json"))
        {
            return true;
        }else return false;
    }
}
