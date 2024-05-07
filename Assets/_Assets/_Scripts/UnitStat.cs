using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStat : MonoBehaviour
{
    public UnitSO _unitSO;
    public float currentHp;

    public float Speed;
    public float  Hp;
    public float AttackDmg;
    public float AttackSpeed;
    public float AttackRange;
    public float Defense;

    public virtual UnitSO GetUnitSO() { return _unitSO; }
    public virtual void GetUnitStat()
    {
        Speed = _unitSO.Speed.GetValue();
        currentHp = _unitSO.Hp.GetValue();
        Hp = _unitSO.Hp.GetValue();
        AttackDmg = _unitSO.AttackDmg.GetValue();
        AttackSpeed = _unitSO.AttackSpeed.GetValue();
        AttackRange = _unitSO.AttackRange.GetValue();
        Defense = _unitSO.Defense.GetValue();
    }
}
