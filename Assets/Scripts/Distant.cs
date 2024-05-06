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

    [Header("Enemy HitBox")]
    [SerializeField] private BoxCollider2D _vision;
    [SerializeField] private BoxCollider2D _hitBox;
    [SerializeField] private BoxCollider2D _closedAttackRange;
    [SerializeField] private BoxCollider2D _rangedAttackRange;

    private EState _currentState;

    private StateContext _stateContext;

    private void Awake()
    {
        _vision = GetComponent<BoxCollider2D>();
        _hitBox = GetComponent<BoxCollider2D>();
        _closedAttackRange = GetComponent<BoxCollider2D>();
        _rangedAttackRange = GetComponent<BoxCollider2D>();

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 만약 충돌한 콜라이더가 플레이어라면
        if (other.CompareTag("Player"))
        {
            UpdateState(EState.Chase); // Chase 상태로 변경
        }
    }

    //public void CheckPlayerInRange(Transform _playerTransform, float _chaseRange)
    //{
    //    float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
    //    if (distanceToPlayer <= _chaseRange)
    //    {
    //        UpdateState(EState.Chase); // 플레이어가 추적 범위 내에 있으면 ChaseState로 상태 변경
    //    }
    //}
}
