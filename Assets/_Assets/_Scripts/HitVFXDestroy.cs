using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVFXDestroy : MonoBehaviour
{
    public void DestroyVFX() {  Destroy(gameObject.transform.parent.gameObject); }
}
