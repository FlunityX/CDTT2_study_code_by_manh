using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmNGUI : MonoBehaviour
{
    [SerializeField] private Button confirmBtn;
    [SerializeField] private Button cancelBtn;
    void Start()
    {
        confirmBtn.onClick.AddListener(() =>
        {
            SaveSystem.SetNewData();
            SaveSystem.LoadNewScene();
        });
        cancelBtn.onClick.AddListener(() =>
        {
            Hide();
        });
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
