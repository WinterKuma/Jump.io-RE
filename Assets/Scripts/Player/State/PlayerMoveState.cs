using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState, IStateAddable, IStateRemoveAble
{
    private float moveSpeed;
    private Vector3 moveDirection;

    protected override void Awake()
    {
        base.Awake();
        stateType = PlayerStateType.Move;
        AddState();
    }

    protected override void Start()
    {
        base.Start();
        playerController.updateCurrentStatus.AddListener(UpdateCurrentStatus);
        playerController.updateMoveDirection.AddListener(UpdateMoveDirection);
    }

    public void AddState()
    {
        playerController.AddState(stateType, this);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (Mathf.Abs(moveDirection.x) <= 0.1f)
        {
            playerController.ChangeState(PlayerStateType.Idle);
        }
        else {
            transform.position += Vector3.right * moveDirection.x * moveSpeed * Time.deltaTime;
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

    public void UpdateCurrentStatus(PlayerStatus currentStatus)
    {
        moveSpeed = currentStatus.moveSpeed;
    }


}
