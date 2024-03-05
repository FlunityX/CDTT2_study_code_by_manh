using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour, IUnitStat
{
    public float Speed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float Hp { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float AttackDmg { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float AttackSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public UnitSO UnitSO => throw new System.NotImplementedException();

    public float AttackRange { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void GetPlayerStat() { }
}
