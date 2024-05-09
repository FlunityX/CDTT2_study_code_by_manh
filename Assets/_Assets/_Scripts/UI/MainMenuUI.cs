using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button newGameBtn;
    [SerializeField] private Button LoadBtn;
    [SerializeField] private Button SettingBtn;
    [SerializeField] private Button QuitBtn;
    [SerializeField] private Transform SettingUI;
    [SerializeField] private Transform confirmUI;
    void Start()
    {
        newGameBtn.onClick.AddListener(() =>
        {
            if (SaveSystem.CheckFileExist())
            {
                confirmUI.gameObject.SetActive(true);
            }
            else
            {
                SaveSystem.SetNewData();
                Loader.Load(Loader.Scene.GameLevel1);
            }
        });
        LoadBtn.onClick.AddListener(() => { 
            SaveSystem.LoadCurrentScene();
            });
        QuitBtn.onClick.AddListener(() => { Application.Quit(); });
        
        SettingBtn.onClick.AddListener(() => {
            gameObject.SetActive(true);
            SettingUI.gameObject.SetActive(true);
        });

        if(!SaveSystem.CheckFileExist())
        {
            LoadBtn.gameObject.SetActive(false);
        }
    }

    
}
