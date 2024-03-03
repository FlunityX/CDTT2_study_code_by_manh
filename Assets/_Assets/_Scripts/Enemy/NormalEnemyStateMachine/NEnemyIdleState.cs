using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEnemyIdleState : NEnemyBaseState
{
    private NEnemyManager _NEenemyManager;
    private float entryTime;
    private float restTime = 2f;
    private float activeRange = 4f;
    
    public override void EnterState(CharacterManager characterManager)
    {
        base.EnterState(characterManager);
        _NEenemyManager = (NEnemyManager)characterManager;
    }

    public override void ExitState()
    {
       base.ExitState();
    }

    public override void Update()
    {
        if (CheckIfCanPatrol())
        {
            _NEenemyManager.ChangeState(_NEenemyManager.GetNEnemyPartrolState());   
        }
    }

    private  bool CheckIfCanPatrol()
    {
        return Time.time - entryTime > restTime;
    }
    
    private bool CheckIfCanChase()
    {
        return true;
    }
   


    public override void FixedUpdate() { }
}
