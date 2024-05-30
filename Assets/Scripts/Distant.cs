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
    //>:C

    //[Header("Enemy HitBox")]
    //[SerializeField] private BoxCollider2D _vision;
    //[SerializeField] private BoxCollider2D _hitBox;
    //[SerializeField] private BoxCollider2D _closedAttackRange;
    //[SerializeField] private BoxCollider2D _rangedAttackRange;

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

    [Header("HP")]
    [SerializeField] private float health = 100f;

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
        Vision();
    }

    void FixedUpdate()
    {
        _stateContext.CurrentState.FixedUpdateState();
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
    
    

    private void Vision()
    {
        bool _lookHit = Physics2D.BoxCast(transform.position, new Vector2(_lookVisionX, _lookVisionY), 0f, Vector2.zero, 0, _whatIsPlayer);
        bool _attackLookHit = Physics2D.BoxCast(transform.position, new Vector2(_attackVisionX, _attackVisionY), 0f, Vector2.zero, 0, _whatIsPlayer);

        if (_attackLookHit)
        {
            UpdateState(EState.Attack);
        }
        else if (_lookHit)
        {
            UpdateState(EState.Chase);
        }
        else
        {
            UpdateState(EState.Idle);
        }
    }

    void OnDrawGizmos()
    {
        //1
        Gizmos.color = UnityEngine.Color.red;
        DrawBox(transform.position, new Vector2(_lookVisionX, _lookVisionY));
        //2
        Gizmos.color = UnityEngine.Color.blue;
        DrawBox(transform.position, new Vector2(_attackVisionX, _attackVisionY));
    } 

    // Draw a box using lines
    void DrawBox(Vector3 center, Vector2 size)
    {
        // Calculate half size to draw from center
        Vector2 halfSize = size / 2f;

        // Get box corners
        Vector3 topLeft = center + new Vector3(-halfSize.x, halfSize.y);
        Vector3 topRight = center + new Vector3(halfSize.x, halfSize.y);
        Vector3 bottomRight = center + new Vector3(halfSize.x, -halfSize.y);
        Vector3 bottomLeft = center + new Vector3(-halfSize.x, -halfSize.y);

        // Draw lines
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void ApplyKnockback(Vector2 hitPosition, float knockbackPower)
    {
        Vector2 knockbackDirection = (transform.position - (Vector3)hitPosition).normalized;
        GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);
    }

    private void Die()
    {
        // 적이 죽었을 때의 로직
        Destroy(gameObject);
    }

}
