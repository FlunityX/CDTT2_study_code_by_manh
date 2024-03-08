using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : CharacterManager
{
    public Boss _Boss;
    
    public BossIdleState _IdleState = new();
    public BossWalkState _WalkState = new();
    public BossMeleeAttackState _MeleeAttack =new();
    public BossCastSpellState _CastSpellState = new();
    public BossHurtState _HurtState = new();
    public BossDeathState _DeathState = new();

    


    private void Start()
    {
        SetUpProperties();
    }
    protected override void Update()
    {
        base.Update();
    }
    private void SetUpProperties()
    {
        _state = _IdleState;
        _state.EnterState(this);
    }
}
