using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotionState : PlayerBaseState
{
    private float gethitTime = .5f;
    private float gethitTimeCounter;
    private Vector2 usePos;
    public override void EnterState(PlayerStateManager playerStateManager)
    {

        base.EnterState(playerStateManager);
        Player.Instance._playerVisual.PlayUsePotionAnim();
        usePos = Player.Instance.transform.position;
        Debug.Log("heal");
    }

    public override void ExitState()
    {
        gethitTimeCounter = 0;
    }

    public override void Update()
    {
        gethitTimeCounter += Time.deltaTime;
        Player.Instance.isUsePotion = false;

        NailPlayer();
        if (CheckIfCanIdle())
        {
            _playerStateManager.ChangeState(_playerStateManager.idleState);

        }
        else if (CheckIfCanRun())
        {
            _playerStateManager.ChangeState((_playerStateManager.runState));
        }
    }


    private bool CheckIfCanIdle()
    {
        return Player.Instance.GetDirX() == 0 && Player.Instance._playerMovement.isGround && gethitTimeCounter >= gethitTime;
    }

    private bool CheckIfCanRun()
    {
        return (Player.Instance.GetDirX() != 0 && Player.Instance._playerMovement.isGround) && gethitTimeCounter >= gethitTime;
    }

    private void NailPlayer()
    {
        Player.Instance.transform.position = usePos;
    }

    public override void FixedUpdate()
    {

    }
}
