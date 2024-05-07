using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatusIconUI : MonoBehaviour
{
    [SerializeField] private Image statusIcon;
    [SerializeField] private Image frontGround;
    
    public int index;
    private void Start()
    {
        
    }
    void Update()
    {
        statusIcon.sprite = Player.Instance._statusHolder.statusEffects[index].icon;
        frontGround.fillAmount = (Player.Instance._statusHolder.statusEffects[index].counter / Player.Instance._statusHolder.statusEffects[index].duration);
        Hide();
    }

    private void Hide()
    {
        if(frontGround.fillAmount >=1)
        {
            gameObject.SetActive(false);
        }
    }
}
