using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameObject PlayerHitVFX;
    public GameObject DropItem;
    public GameObject Chest_Diamond;
    public GameObject Chest_Gold;
    public GameObject Chest_Wood;
    public GameObject Chest_Empty;
    private void Awake()
    {
        PlayerHitVFX = Resources.Load<GameObject>("Prefab/HitParticle");
        DropItem = Resources.Load<GameObject>("Prefab/object/DropItem");
        Chest_Diamond = Resources.Load<GameObject>("Prefab/object/diamon chest");
        Chest_Gold = Resources.Load<GameObject>("Prefab/object/golden chest");
        Chest_Wood = Resources.Load<GameObject>("Prefab/object/wooden chest");
        Chest_Empty = Resources.Load<GameObject>("Prefab/object/empty chestt");
    }
}
