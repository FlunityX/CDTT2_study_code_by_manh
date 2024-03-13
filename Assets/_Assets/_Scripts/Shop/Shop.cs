using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    [SerializeField] private ShopUI shopUI;
    [SerializeField] private Transform shopTile;

    public void InteractHandler()
    {
        shopUI.ShopOpen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag(GameConstant.PLAYER_TAG))
            {
                shopTile.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag(GameConstant.PLAYER_TAG))
            {
                shopTile.gameObject.SetActive(false);

            }

        }
    }

}
