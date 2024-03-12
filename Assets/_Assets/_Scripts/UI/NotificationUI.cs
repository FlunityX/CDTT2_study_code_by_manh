using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class NotificationUI : MonoBehaviour
{

    public static NotificationUI Instance;
    public TextMeshProUGUI NotifText;
   public float ShowTime=.5f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show(string notiText)
    {
        NotifText.text = notiText;
        gameObject.SetActive(true);
        Invoke("Hide", ShowTime);
    }
    public void Hide()
    {
        gameObject.SetActive(false );
    }
}
