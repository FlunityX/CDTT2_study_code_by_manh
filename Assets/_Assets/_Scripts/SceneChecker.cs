
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChecker : MonoBehaviour
{
    public static SceneChecker Instance;
    public bool isFirstTime = true;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        if (Loader.GetCurrentScene() != Loader.Scene.MenuScene.ToString())
        {
            Player.Instance.OnPlayerSave += Player_OnPlayerSave;
            
        }
    }

    private void Player_OnPlayerSave(object sender, System.EventArgs e)
    {
        isFirstTime = false;
    }
}
