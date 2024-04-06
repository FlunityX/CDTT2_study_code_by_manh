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
    private void Awake()
    {
        
            Instance = this;
        
    }
    private void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
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
        }
        else
        {
            Time.timeScale = 1;
            isGamePause = false;
            GameInput.Instance.EnableGameInput();

            OnGameResume?.Invoke(this, EventArgs.Empty);
        }
    }
}
