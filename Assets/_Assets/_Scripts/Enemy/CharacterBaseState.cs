using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState 
{
    protected CharacterManager _characterManager;

    public virtual void EnterState(CharacterManager characterManager) { _characterManager = characterManager; }

    public virtual void ExitState() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }
}
