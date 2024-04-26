using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameObject PlayerHitVFX;
    public GameObject DropItem;
    //public GameObject GoblinRangedArrow;
    private void Awake()
    {
        PlayerHitVFX = Resources.Load<GameObject>("Prefab/HitParticle");
        DropItem = Resources.Load<GameObject>("Prefab/object/DropItem");
        //GoblinRangedArrow = Resources.Load<GameObject>("Prefab/mob/GoblinRangedArrow");
    }
}
