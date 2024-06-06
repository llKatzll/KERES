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

    [Header("CheckPlayer")]
    [SerializeField] private bool _closeAttack = false;
    [SerializeField] private bool _rangedAttack = false;
    [SerializeField] private float _lookVisionX;
    [SerializeField] private float _lookVisionY;
    [SerializeField] private LayerMask _whatIsPlayer;

    [Header("CheckPlayer : Attack")]
    [SerializeField] private bool _attackReady = false;
    [SerializeField] private float _attackVisionX;
    [SerializeField] private float _attackVisionY;

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

    }

    void Update()
    {
        _stateContext.CurrentState.UpdateState();
        if (!_visionChecked)
        {
            Vision();
        }
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

    private void Vision()
    {
        bool _lookHit = Physics2D.BoxCast(transform.position, new Vector2(_lookVisionX, _lookVisionY), 0f, Vector2.zero, 0, _whatIsPlayer);
        bool _attackLookHit = Physics2D.BoxCast(transform.position, new Vector2(_attackVisionX, _attackVisionY), 0f, Vector2.zero, 0, _whatIsPlayer);

        if (_attackLookHit)
        {
            UpdateState(EState.Attack);
        }
        else if (_lookHit && !_attackState._isAttackingCoroutineRunning)
        {
            _lookVisionX = _lookVisionX * 2.5f;
            _lookVisionY = _lookVisionY * 2.5f;
            UpdateState(EState.Chase);
        }
        else
        {
            UpdateState(EState.Idle);
        }

        _visionChecked = true; // Vision 함수가 한 번만 실행되도록 설정
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        DrawBox(transform.position, new Vector2(_lookVisionX, _lookVisionY));
        Gizmos.color = UnityEngine.Color.blue;
        DrawBox(transform.position, new Vector2(_attackVisionX, _attackVisionY));
    }

    void DrawBox(Vector3 center, Vector2 size)
    {
        Vector2 halfSize = size / 2f;

        Vector3 topLeft = center + new Vector3(-halfSize.x, halfSize.y);
        Vector3 topRight = center + new Vector3(halfSize.x, halfSize.y);
        Vector3 bottomRight = center + new Vector3(halfSize.x, -halfSize.y);
        Vector3 bottomLeft = center + new Vector3(-halfSize.x, -halfSize.y);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
