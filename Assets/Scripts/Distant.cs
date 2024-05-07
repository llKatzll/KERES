using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    //>:C

    //[Header("Enemy HitBox")]
    //[SerializeField] private BoxCollider2D _vision;
    //[SerializeField] private BoxCollider2D _hitBox;
    //[SerializeField] private BoxCollider2D _closedAttackRange;
    //[SerializeField] private BoxCollider2D _rangedAttackRange;

    [Header("CheckPlayer")]
    [SerializeField] private bool _looked = false;
    [SerializeField] private bool _closeAttack = false;
    [SerializeField] private bool _rangedAttack = false;
    [SerializeField] private LayerMask _whatIsPlayer;

    private EState _currentState;

    private StateContext _stateContext;

    private void Awake()
    {
        //_vision = GetComponent<BoxCollider2D>();
        //_hitBox = GetComponent<BoxCollider2D>();
        //_closedAttackRange = GetComponent<BoxCollider2D>();
        //_rangedAttackRange = GetComponent<BoxCollider2D>();

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
    }

    void FixedUpdate()
    {
        _stateContext.CurrentState.FixedUpdateState();
        Vision();
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

    [SerializeField] private float _visionX;
    [SerializeField] private float _visionY;

    private void Vision()
    {
        bool hit = Physics2D.BoxCast(transform.position, new Vector2(_visionX, _visionY), 0f, Vector2.zero, 0, _whatIsPlayer);

        if (hit && _looked == false)
        {
            UpdateState(EState.Chase);
            _looked = true;
        }
        else if (!hit && _looked == true)
        {
            UpdateState(EState.Idle);
            _looked = false;
        }
    }

    private void OnDrawGizmos()
    {

    }



    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player") /*&& other == _vision*/)
    //    {
    //        Debug.Log("닿았음!");
    //        UpdateState(EState.Chase); // Chase 상태로 변경
    //    }
    //}

    //public void CheckPlayerInRange(Transform _playerTransform, float _chaseRange)
    //{
    //    float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
    //    if (distanceToPlayer <= _chaseRange)
    //    {
    //        UpdateState(EState.Chase); // 플레이어가 추적 범위 내에 있으면 ChaseState로 상태 변경
    //    }
    //}
}
