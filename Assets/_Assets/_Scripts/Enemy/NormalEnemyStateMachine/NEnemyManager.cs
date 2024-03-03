using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyManager : CharacterManager
{
    [SerializeField]private NEnemyPartrolState _NEnemyPartrolState= new();
    [SerializeField] private NEnemyAttackState _NEnemyAttackState= new();
    [SerializeField] private NEnemyBaseState _NEnemyBaseState= new();
    [SerializeField] private NEnemyIdleState _NEnemyIdleState= new();
    [SerializeField] private NEnemyGetHitState _NEnemyGetHitState= new();
    [SerializeField]private NEnemyChaseState _NEnemyChaseState= new();

    public NEnemyIdleState GetNEnemyIdleState() { return _NEnemyIdleState; }
    public NEnemyAttackState GetNEnemyAttackState() { return _NEnemyAttackState; }
    public NEnemyChaseState GetNEnemyChaseState() { return _NEnemyChaseState;}
    public NEnemyGetHitState GetNEnemyGetHitState() { return _NEnemyGetHitState;}
    public NEnemyPartrolState GetNEnemyPartrolState() { return _NEnemyPartrolState;}


}
