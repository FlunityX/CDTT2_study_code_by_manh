using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }
    public event EventHandler OnGamePause;
    public event EventHandler OnGameResume;
    private bool isGamePause=false;
    public SoundManager soundManager;
    public MusicManager musicManager;
    public ResourceManager resourceManager;
    public GameObject chestHolder;
    private void Awake()
    {

        if (Instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
        
        chestHolder = GameObject.Find("chestHolder");

       SaveSystem.LoadData();
      Player.Instance.SpawnOnLastCheckPoint();

    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
       PauseGame();
    }

    public void PauseGame()
    {
        if (!isGamePause)
        {
            Time.timeScale = 0;
            isGamePause = true;
            GameInput.Instance.DisableGameInput();
            OnGamePause?.Invoke(this, EventArgs.Empty);
            Debug.Log("p�ue");
        }
        else
        {
            Time.timeScale = 1;
            isGamePause = false;
            GameInput.Instance.EnableGameInput();

            OnGameResume?.Invoke(this, EventArgs.Empty);
        }
    }

    
    public void DestroyCurrentChest()
    {
        foreach(Transform child in chestHolder.transform)
        {
            Destroy(child.gameObject);
        }
        Debug.Log("Destroy current chest");
    }
    public void InstantiateNewChest(ChestSO chestSO,Vector2 pos)
    {
        if (chestSO.chestName == GameConstant.DIAMOND_CHEST)
        {
            Instantiate(resourceManager.Chest_Diamond, pos, Quaternion.identity, chestHolder.transform);
        }
        else if (chestSO.chestName == GameConstant.GOLD_CHEST)
        {
            Instantiate(resourceManager.Chest_Gold, pos, Quaternion.identity, chestHolder.transform);
        }
        else if (chestSO.chestName == GameConstant.WOOD_CHEST)
        {
            Instantiate(resourceManager.Chest_Wood, pos, Quaternion.identity, chestHolder.transform);
        }
        else if (chestSO.chestName == GameConstant.EMPTY_CHEST)
        {
            Instantiate(resourceManager.Chest_Empty, pos, Quaternion.identity, chestHolder.transform);
        }


    }
}
