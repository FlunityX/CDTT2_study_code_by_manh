using UnityEngine;


[CreateAssetMenu()]

public class PotionSO : ItemSO, IConsumable
{

    public float HealAmount;
    public void OnConsume()
    {
        Player.Instance.HealHp(HealAmount);
        Debug.Log("used");
    }

    



}
