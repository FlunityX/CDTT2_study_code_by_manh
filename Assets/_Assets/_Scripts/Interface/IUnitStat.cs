using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitStat 
{
    UnitSO UnitSO { get; }

    float Speed { get; set; }
    float Hp { get; set; }
    float AttackDmg { get; set; }
    float AttackSpeed { get; set; }
}
