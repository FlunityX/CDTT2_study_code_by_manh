using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameObject PlayerHitVFX;
    public GameObject DropItem;
    private void Start()
    {
        PlayerHitVFX = Resources.Load<GameObject>("Prefab/HitParticle");
        DropItem = Resources.Load<GameObject>("Prefab/object/DropItem");
    }
}
