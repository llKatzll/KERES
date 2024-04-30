using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Distant : MonoBehaviour
{

    [Header("Enemy States")]
    [SerializeField] private IdleState _idleState;
    [SerializeField] private ChaseState _chaseState;
    [SerializeField] private AttackState _attackState;
    [SerializeField] private HittingState _hittingState;
    [SerializeField] private DeadState _deadState;
    //>:C

    private EState _currentState;

    private StateContext _stateContext;

    private void Awake()
    {
        _stateContext = new StateContext();
        UpdateState(EState.Idle);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _stateContext.CurrentState.UpdateState();
        //늑대가되 ㅠㅠ
    }

    //상태를 업데이트 하는 함수에용
    public void UpdateState(EState state)
    {
        switch (state)
        {
            case EState.Idle:
                _stateContext.Transition(_idleState);
                break;
            case EState.Chase:
                _stateContext.Transition(_chaseState);
                break;
            case EState.Attack:
                _stateContext.Transition(_attackState);
                break;
            case EState.Hitted:
                _stateContext.Transition(_hittingState);
                break;
            case EState.Dead:
                _stateContext.Transition(_deadState);
                break;
        }
        _currentState = state;
    }
}
