using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    private UnitSO _unitSO;
    public float currentHp;
    public float speed;
    public float Hp;
    public float attackDamage;
    public float attackSpeed;

    private void Start()
    {
        GetEnemyStat();
    }
    public void GetEnemyStat()
    {
        speed = _unitSO.Speed;
        Hp = _unitSO.Hp;
        currentHp = Hp;
        attackDamage = _unitSO.AttackDmg;
        attackSpeed = _unitSO.AttackSpeed;
    }
}
