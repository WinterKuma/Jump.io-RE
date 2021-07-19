using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState, IStateAddable, IStateRemoveAble
{

    protected override void Awake()
    {
        base.Awake();
        stateType = PlayerStateType.Jump;
        AddState();
    }
       

    public void AddState()
    {
        playerController.AddState(stateType, this);
    }

    public void RemoveState()
    {
        playerController.RemoveState(stateType);
    }
}
