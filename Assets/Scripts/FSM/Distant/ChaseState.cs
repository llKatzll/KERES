using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour, DistantState
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;
    public void EnterState()
    {
        Debug.Log("����Ʈ ChaseStart");
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ ChaseEND");
    }
    public void UpdateState()
    {
        Debug.Log("�����̵�");
        if (_target != null)
        {
            // ���� �÷��̾ ���� �̵��ϵ��� ���� ���͸� ���
            Vector2 direction = (_target.position - transform.position).normalized;

            // ���� ���� ��ġ�� �÷��̾� �������� ���ݾ� �̵�
            transform.Translate(direction * _moveSpeed * Time.deltaTime);

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
