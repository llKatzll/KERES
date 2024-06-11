using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour, DistantState
{
    //public string BoolParameterName
    //{
    //    get { return }
    //}

    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;

    [Header("CheckPlayer : Attack")]
    [SerializeField] private bool _attackReady = false;
    [SerializeField] private float _attackVisionX;
    [SerializeField] private float _attackVisionY;
    [SerializeField] private LayerMask _whatIsPlayer;

    Animator _anim;
    AttackState _attackState;
    Distant _distant;

    public void EnterState()
    {
        Debug.Log("디스턴트 ChaseStart");
        _anim = GetComponent<Animator>();
        _attackState = GetComponent<AttackState>();
        _distant = GetComponent<Distant>();
        if (_attackState._isAttackingCoroutineRunning)
        {
            // 현재 공격 중이라면 ChaseState로 진입하지 않음
            Debug.Log("공격 중에는 ChaseState로 진입할 수 없습니다.");
            return;
        }
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 ChaseEND");
    }
    public void UpdateState()
    {
        AttackVision();
    }
    public void FixedUpdateState()
    {
        Debug.Log("괴물이되");

        if (_target != null)
        {
            // 적이 플레이어를 향해 이동하도록 방향 벡터를 계산
            Vector2 direction = (_target.position - transform.position).normalized;

            // 적의 현재 위치를 플레이어 방향으로 조금씩 이동
            transform.Translate(direction * _moveSpeed * Time.deltaTime);

            _anim.SetBool(AnimationStrings.IsMove, true);

            // 적이 플레이어를 바라보도록 방향을 설정
            if (direction.x > 0)
            {
                // 플레이어가 오른쪽에 있는 경우
                transform.localScale = new Vector2(-2.7f, 2.7f);// 적을 좌우 반전하여 오른쪽을 바라보게 함
            }
            else
            {
                // 플레이어가 왼쪽에 있는 경우
                transform.localScale = new Vector2(2.7f, 2.7f); // 적을 좌우 반전하지 않고 왼쪽을 바라보게 함
            }
        }
    }

    void AttackVision()
    {
        bool _attackLookHit = Physics2D.BoxCast(transform.position, new Vector2(_attackVisionX, _attackVisionY), 0f, Vector2.zero, 0, _whatIsPlayer);
        //추격 도중 공격 범위 진입 시 공격함
        if (_attackLookHit && _attackState._isAttack == false)
        {
            _attackState._isAttack = true;
            _distant.UpdateState(EState.Attack);
        }
        else
        {
            _attackState._isAttack = false;
        }
    }

    void OnDrawGizmos()
    {
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
