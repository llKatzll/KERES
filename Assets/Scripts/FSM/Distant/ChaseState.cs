using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour, DistantState
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;

    Animator _anim;

    public void EnterState()
    {
        Debug.Log("����Ʈ ChaseStart");
        _anim = GetComponent<Animator>();
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ ChaseEND");
    }
    public void UpdateState()
    {
        
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

            //_anim.SetBool(AnimationStrings.IsMove, true);

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
}
