using System;
using UnityEngine.UI;
using UnityEngine;

public class BossHPBarUI : MonoBehaviour
{
    [SerializeField] private Image HpBarImage;
    [SerializeField] private Boss _boss;

    //[SerializeField] private TextMeshProUGUI playerHpText;
    public event EventHandler<IHasHpBar.OnHpChangeEventArgs> OnHpChange;


    private void Start()
    {


        _boss.OnHpChange += Boss_OnHpChange;

        HpBarImage.fillAmount = 1;

        // playerHpText.text = Player.Instance.currentHp.ToString()+ "/" + Player.Instance.HpMax.ToString() ;
    }

    private void Boss_OnHpChange(object sender, IHasHpBar.OnHpChangeEventArgs e)
    {
        HpBarImage.fillAmount = e.HpNormalized;
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
