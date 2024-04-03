using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class UnitSO :ScriptableObject
{
    public string UnitName;
   public Stat Speed;
    public Stat Hp;
    public Stat AttackDmg;
    public Stat AttackSpeed;
    public Stat AttackRange;
}
