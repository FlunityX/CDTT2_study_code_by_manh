using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : CharacterManager
{
       public Boss _Boss { get; private set; }

    


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
        //_state ;
        _state.EnterState(this);
    }
}
