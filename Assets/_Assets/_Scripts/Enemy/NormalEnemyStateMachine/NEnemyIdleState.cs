using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class NEnemyIdleState : NEnemyBaseState
{
    //private NEnemyManager _NEenemyManager;
    [SerializeField]private float entryTime;
    private float restTime = 2f;

    
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEnemyManager = (NEnemyManager)characterManager;
        entryTime = Time.time;
        Debug.Log("chillin");


    }

    public override void ExitState()
    {
       base.ExitState();
        
    }

    public override void Update()
    {
        if (CheckIfCanPatrol())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyPartrolState);
        }
        else if(CheckIfCanChase())
        {
            _NEnemyManager.ChangeState(_NEnemyManager._NEnemyChaseState);
        }
    }

    private  bool CheckIfCanPatrol()
    {
        return  Time.time- entryTime >= restTime;

    }

    private bool CheckIfCanChase()
    {
        return _NEnemyManager._normalEnemy.GetNEnemyCollider().CheckIfHitPlayer();
        
    }



    public override void FixedUpdate() {
        entryTime += Time.deltaTime;

    }
}
