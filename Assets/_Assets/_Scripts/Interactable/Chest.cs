using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private ChestSO chestSO;
    [SerializeField] private ChestVisual _chestVisual;
    private void Start()
    {
     _chestVisual = GetComponentInChildren<ChestVisual>();
     
    }
    public void InteractHandler()
    {
        Debug.Log("Chest loot");
        ChestLoot();
        _chestVisual.ChestOpenAnim(chestSO.chestName);
        Invoke("DestroyGameObject", 1f);
    }


   
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    public void ChestLoot()
    {
        int rand = Random.Range(0, 3);
        PlayerInventory.Instance.Add(chestSO.itemSOs[rand]);
        Player.Instance.coin += chestSO.coinAmount;
    }
}
