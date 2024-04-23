using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameObject PlayerHitVFX;

    private void Start()
    {
        PlayerHitVFX = Resources.Load<GameObject>("Prefab/HitParticle");
    }
}
