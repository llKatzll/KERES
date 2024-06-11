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
        Debug.Log("����Ʈ ChaseStart");
        _anim = GetComponent<Animator>();
        _attackState = GetComponent<AttackState>();
        _distant = GetComponent<Distant>();
        if (_attackState._isAttackingCoroutineRunning)
        {
            // ���� ���� ���̶�� ChaseState�� �������� ����
            Debug.Log("���� �߿��� ChaseState�� ������ �� �����ϴ�.");
            return;
        }
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ ChaseEND");
    }
    public void UpdateState()
    {
        AttackVision();
    }
    public void FixedUpdateState()
    {
        Debug.Log("�����̵�");

        if (_target != null)
        {
            // ���� �÷��̾ ���� �̵��ϵ��� ���� ���͸� ���
            Vector2 direction = (_target.position - transform.position).normalized;

            // ���� ���� ��ġ�� �÷��̾� �������� ���ݾ� �̵�
            transform.Translate(direction * _moveSpeed * Time.deltaTime);

            _anim.SetBool(AnimationStrings.IsMove, true);

            // ���� �÷��̾ �ٶ󺸵��� ������ ����
            if (direction.x > 0)
            {
                // �÷��̾ �����ʿ� �ִ� ���
                transform.localScale = new Vector2(-2.7f, 2.7f);// ���� �¿� �����Ͽ� �������� �ٶ󺸰� ��
            }
            else
            {
                // �÷��̾ ���ʿ� �ִ� ���
                transform.localScale = new Vector2(2.7f, 2.7f); // ���� �¿� �������� �ʰ� ������ �ٶ󺸰� ��
            }
        }
    }

    void AttackVision()
    {
        bool _attackLookHit = Physics2D.BoxCast(transform.position, new Vector2(_attackVisionX, _attackVisionY), 0f, Vector2.zero, 0, _whatIsPlayer);
        //�߰� ���� ���� ���� ���� �� ������
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
