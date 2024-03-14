using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class UnitSO :ScriptableObject
{
    public string UnitName;
   public float Speed;
    public float Hp;
    public float AttackDmg;
    public float AttackSpeed;
    public float AttackRange;
}
