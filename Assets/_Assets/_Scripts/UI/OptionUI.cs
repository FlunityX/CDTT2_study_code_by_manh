using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public static OptionUI Instance { get; private set; }

    [SerializeField] private Button closeButton;
    [SerializeField] private Slider soundVollumeSlider;
    [SerializeField] private Slider musicVollumeSlider;
    [SerializeField] private Button attackBtn;
    [SerializeField] private Button jumpBtn;
    [SerializeField] private Button moveRightBtn;
    [SerializeField] private Button moveLeftBtn;
    [SerializeField] private Button interactBtn;
    [SerializeField] private Button slideBtn;
    [SerializeField] private Button activeItemBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private TextMeshProUGUI soundEffectText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI attackTxt;
    [SerializeField] private TextMeshProUGUI jumpTxt;
    [SerializeField] private TextMeshProUGUI moveRightTxt;
    [SerializeField] private TextMeshProUGUI moveLeftTxt;
    [SerializeField] private TextMeshProUGUI interactTxt;
    [SerializeField] private TextMeshProUGUI slideTxt;
    [SerializeField] private TextMeshProUGUI activeItemTxt;
    [SerializeField] private TextMeshProUGUI pauseTxt;
    [SerializeField] private Transform pressToRebindKeyTransform;

    public Action onCloseButtonAction;
    private void Awake()
    {
        Instance = this;
        soundVollumeSlider.onValueChanged.AddListener((value) =>
        {
           
            GameManager.Instance.soundManager.ChangeVollumme(value);
            UpdateVisual();
        });

        musicVollumeSlider.onValueChanged.AddListener(value =>
        {
            GameManager.Instance.musicManager.ChangeVollume(value);
            UpdateVisual();
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            onCloseButtonAction();
        });

        attackBtn.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Attack);
        });
        jumpBtn.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Jump);

        });
        moveLeftBtn.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Move_Left);

        }); 
        moveRightBtn.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Move_Right);

        });
        interactBtn.onClick.AddListener(() => {
            RebindBinding(GameInput.Binding.Interact);

        });
        slideBtn.onClick.AddListener(() => { 
            RebindBinding(GameInput.Binding.Slide);

        });
        activeItemBtn.onClick.AddListener(() => { 
            RebindBinding(GameInput.Binding.ActiveItem);

        });
        pauseBtn.onClick.AddListener(() => { 
            RebindBinding(GameInput.Binding.Pause);

        });
        attackBtn.Select();
    }

    private void Start()
    {
        //GameManager.Instance.OnGamePause += GameManager_OnGamePause;
        UpdateVisual();
        HidePressToRebind();
        Hide();
    }

    private void GameManager_OnGamePause(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual ()
    {
        soundEffectText.text = "Sound Effect: " + Mathf.Round(GameManager.Instance.soundManager.GetVollume() * 10f);
        musicText.text = "Music: " + Mathf.Round(GameManager.Instance.musicManager.GetVollume() * 10f);
        musicVollumeSlider.value = GameManager.Instance.musicManager.GetVollume();
        soundVollumeSlider.value = GameManager.Instance.soundManager.GetVollume();
        attackTxt.text = GameInput.Instance.GetBindingText(GameInput.Binding.Attack);
        jumpTxt.text = GameInput.Instance.GetBindingText (GameInput.Binding.Jump);
        moveLeftTxt.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightTxt.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        interactTxt.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        slideTxt.text = GameInput.Instance.GetBindingText(GameInput.Binding.Slide);
        activeItemTxt.text = GameInput.Instance.GetBindingText(GameInput.Binding.ActiveItem);
        pauseTxt.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);


    }

    public void Show(Action onCloseButtonAction)
    {
        this.onCloseButtonAction = onCloseButtonAction;
        gameObject.SetActive(true);
        attackBtn.Select();
        UpdateVisual();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void ShowPressToRebind()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }
    public void HidePressToRebind()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebind();
        GameInput.Instance.RebidnBinding(binding,()=> {
            HidePressToRebind();
            UpdateVisual();
        }
        );
    }
}
