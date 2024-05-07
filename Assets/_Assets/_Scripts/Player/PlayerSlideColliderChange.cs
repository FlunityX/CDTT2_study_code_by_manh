using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideColliderChange : MonoBehaviour
{
    public void TurnOnSlideCollider()
    {
      //  Player.Instance.SlideCollider.enabled = true;
        Player.Instance.Collider.enabled = false;
    }
    public void TurnOffSlideCollider()
    {
      //  Player.Instance.SlideCollider.enabled = false;
        Player.Instance.Collider.enabled = true;
    }
}
