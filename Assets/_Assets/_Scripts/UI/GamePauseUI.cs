using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingButton;
   
    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.PauseGame();
        });
        menuButton.onClick.AddListener(() =>
        {
           // Loader.Load(Loader.Scene.MainMenu);
        });

        settingButton.onClick.AddListener(() =>
        {
            Hide();
            OptionUI.Instance.Show(Show);
        });
    }
    private void Start()
    {
        GameManager.Instance.OnGamePause += Instance_OnGamePause;
        GameManager.Instance.OnGameResume += Instance_OnGameResume;
        Hide();
    }

    private void Instance_OnGamePause(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Instance_OnGameResume(object sender, System.EventArgs e)
    {
        Hide();
    }

    

    private void Show()
    {
        gameObject.SetActive(true);
        resumeButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
