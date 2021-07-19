using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    PhotonView photonView;

    [SerializeField]
    private PlayerStatus originStatus;
    [SerializeField]
    private PlayerStatus currentStatus;
    public UnityEvent<PlayerStatus> updateCurrentStatus = new UnityEvent<PlayerStatus>();

    [SerializeField]
    private PlayerStateType currentStateType;
    private Dictionary<PlayerStateType, PlayerState> states = new Dictionary<PlayerStateType, PlayerState>();

    [SerializeField]
    private Vector3 moveDirection;
    public UnityEvent<Vector3> updateMoveDirection = new UnityEvent<Vector3>();

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        ChangeState(PlayerStateType.Idle);
    }

    private void Update()
    {
        //TODO :: UPDATE INPUT

        //Check LocalPlayer
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        updateMoveDirection?.Invoke(moveDirection);
        UpdateState();
    }

    public bool AddState(PlayerStateType addStateType, PlayerState newState)
    {
        if (addStateType == PlayerStateType.None || newState == null)
            return false;

        states.Add(addStateType, newState);
        return true;
    }
    public bool RemoveState(PlayerStateType removeStateType)
    {
        if (removeStateType == PlayerStateType.None)
            return false;

        states.Remove(removeStateType);
        return true;
    }

    public void ChangeState(PlayerStateType newStateType)
    {
        currentStateType = newStateType;
    }

    protected void UpdateState()
    {
        switch (currentStateType)
        {
            case PlayerStateType.Idle:
                break;
            case PlayerStateType.Move:
                updateCurrentStatus.Invoke(currentStatus);
                break;
            case PlayerStateType.Jump:
                updateCurrentStatus.Invoke(currentStatus);
                break;
            case PlayerStateType.KnockBack:
                updateCurrentStatus.Invoke(currentStatus);
                break;
            default:
                break;
        }

        if (states.ContainsKey(currentStateType))
        {
            var currentState = states[currentStateType];
            currentState.UpdateState();
        }

    }

    public PlayerStatus GetOriginStatus()
    {
        return originStatus;
    }

    public PlayerStatus GetCurrentStatus()
    {
        return currentStatus;
    }


}
