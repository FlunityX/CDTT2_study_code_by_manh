
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
        Debug.Log("loaded");

    }
}
