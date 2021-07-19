using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : UnitState
{
    protected PlayerController playerController;
    protected PlayerStateType stateType;

    protected override void Awake() {
        base.Awake();
        playerController = GetComponent<PlayerController>();
    }


}
