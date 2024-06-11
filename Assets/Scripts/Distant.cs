using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class Distant : MonoBehaviour
{
    [Header("Enemy States")]
    [SerializeField] private IdleState _idleState;
    [SerializeField] private ChaseState _chaseState;
    [SerializeField] private AttackState _attackState;
    [SerializeField] private HittingState _hittingState;
    [SerializeField] private DeadState _deadState;

    [Header("Vision?")]
    [SerializeField] private bool _visionChecked = false;

    [Header("HP")]
    public float health = 100f;

    private EState _currentState;
    private StateContext _stateContext;

    

    private void Awake()
    {
        _stateContext = new StateContext();
        UpdateState(EState.Idle);
    }

    void Start()
    {
        //TODO : 어택 스테이트에서 공격 무한반복됨. _isAttack으로 조절할까 고뇌중.
    }

    void Update()
    {
        _stateContext.CurrentState.UpdateState();
    }

    void FixedUpdate()
    {
        _stateContext.CurrentState.FixedUpdateState();
    }

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
        _visionChecked = false; // 상태가 변경될 때마다 Vision 함수가 다시 실행되도록 플래그 리셋
    }
}
