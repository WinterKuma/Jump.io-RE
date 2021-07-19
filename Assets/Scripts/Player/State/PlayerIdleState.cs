using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState, IStateAddable, IStateRemoveAble
{
    private Vector3 moveDirection;

    protected override void Awake()
    {
        base.Awake();
        stateType = PlayerStateType.Idle;
        AddState();
    }

    protected override void Start()
    {
        base.Start();
        playerController.updateMoveDirection.AddListener(UpdateMoveDirection);
    }

    public void AddState()
    {
        playerController.AddState(stateType, this);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (Mathf.Abs(moveDirection.x) > 0.1f)
        {
            playerController.ChangeState(PlayerStateType.Move);
        }
    }

    public void RemoveState()
    {
        playerController.RemoveState(stateType);
    }

    public void UpdateMoveDirection(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;
    }


}
