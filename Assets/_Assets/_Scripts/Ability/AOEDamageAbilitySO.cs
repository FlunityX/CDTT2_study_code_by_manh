using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AOEDamageAbilitySO : AbilitySO
{
    public GameObject skillPrefab;
    public override void Activate(GameObject holder)
    {
        base.Activate(holder);

        Instantiate(skillPrefab,holder.transform.position, Quaternion.identity); 
    }
    public override void Deactivate(GameObject holder)
    {
        base.Deactivate(holder);
       
        
    }
    
}
