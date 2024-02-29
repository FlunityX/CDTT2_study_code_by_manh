using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBarUI : MonoBehaviour, IHasHpBar
{

    [SerializeField] private Image HpBarImage;
   
    //[SerializeField] private TextMeshProUGUI playerHpText;
    public event EventHandler<IHasHpBar.OnHpChangeEventArgs> OnHpChange;


    private void Start()
    {


        Player.Instance.OnHpChange += HasHpBar_OnHpChange;

        HpBarImage.fillAmount = 1;
       
        // playerHpText.text = Player.Instance.currentHp.ToString()+ "/" + Player.Instance.HpMax.ToString() ;
    }

    private void HasHpBar_OnHpChange(object sender, IHasHpBar.OnHpChangeEventArgs e)
    {
        HpBarImage.fillAmount = e.HpNormalized;
        // playerHpText.text = Player.Instance.currentHp.ToString() + "/" + Player.Instance.HpMax.ToString();
    }

}
