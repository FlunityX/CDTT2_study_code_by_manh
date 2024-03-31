using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStat : MonoBehaviour
{
    public UnitSO _unitSO;
    public float currentHp;

    public float Speed;
    public float Hp;
    public float AttackDmg;
    public float AttackSpeed;
    public float AttackRange;

    public virtual UnitSO GetUnitSO() { return _unitSO; }
    public virtual void GetUnitStat()
    {
        Speed = _unitSO.Speed;
        currentHp = _unitSO.Hp;
        Hp = _unitSO.Hp;
        AttackDmg = _unitSO.AttackDmg;
        AttackSpeed = _unitSO.AttackSpeed;
        AttackRange = _unitSO.AttackRange;
    }
}
