using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NotificationUI : MonoBehaviour
{
    
   public float ShowTime=.5f;
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Invoke("Hide", ShowTime);
    }
    public void Hide()
    {
        gameObject.SetActive(false );
    }
}
