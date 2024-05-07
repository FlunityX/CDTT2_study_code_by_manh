using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button PlayBtn;
    [SerializeField] private Button LoadBtn;
    [SerializeField] private Button SettingBtn;
    [SerializeField] private Button QuitBtn;
    [SerializeField] private Transform SettingUI;
    void Start()
    {
        PlayBtn.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
        LoadBtn.onClick.AddListener(() => { });
        QuitBtn.onClick.AddListener(() => { Application.Quit(); }); 
        SettingBtn.onClick.AddListener(() => {
            gameObject.SetActive(true);
            SettingUI.gameObject.SetActive(true);
        });
    }

    
}
