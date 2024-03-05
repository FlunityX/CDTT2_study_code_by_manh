using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IHasHpBar,IDealDamage,IReceiveDamage
{
    public static Player Instance {  get; private set; }
    public PlayerMovement _playerMovement;
    [SerializeField]public PlayerVisual _playerVisual;
    [SerializeField] public PlayerAttack _playerAttack;
    [SerializeField] public PlayerCollider _playerCollider;

    public float Speed=1f;
    public float Dmg=1f;
    public float HpMax = 10;
    public float currentHp = 1;
    
    public event EventHandler<IHasHpBar.OnHpChangeEventArgs> OnHpChange;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerVisual = GetComponentInChildren<PlayerVisual>();
        _playerAttack = GetComponentInChildren<PlayerAttack>();
    }

    //deal dmg and receive dmg
    public void DealDamage(IReceiveDamage receiveDmg, float dmg)
    {
        receiveDmg.ReduceHp(dmg);
    }

    public void ReduceHp(float dmg)
    {
        currentHp -= dmg;
        OnHpChange?.Invoke(this, new IHasHpBar.OnHpChangeEventArgs
        {
            HpNormalized = currentHp / HpMax
        }); ;
    }
    //return value
    public float GetDirX()
    {
        return _playerMovement.dirX;
    }
    public Rigidbody2D GetRigidbody()
    {
        return _playerMovement._boxRigidbody;
    }

}
