using System.Collections;
using UnityEngine;

public class AttackState : MonoBehaviour, DistantState
{
    Animator _anim;
    Distant _distant;

    [Header("Distant Attack Boolean")]
    [SerializeField] private bool _isAttack = false;
    [SerializeField] private bool _isAttackingCoroutineRunning = false; // �ڷ�ƾ ���� ���θ� Ȯ���ϴ� �÷���

    [Header("Distant Attack figure")]
    [SerializeField] private float _attackInterval;

    public void EnterState()
    {
        Debug.Log("����Ʈ AttackStart");
        _anim = GetComponent<Animator>();
        _isAttack = true;
        if (!_isAttackingCoroutineRunning)
        {
            StartCoroutine(RepeatAttack());
        }
    }

    public void ExitState()
    {
        Debug.Log("����Ʈ AttackEND");
        _isAttack = false;
    }

    public void UpdateState()
    {
        Debug.Log("����Ʈ Attack");

        // UpdateState���� ������ �ݺ� ������ ó���� �ʿ� ����
        // �ڷ�ƾ���� �ݺ� ���� ó��
    }

    IEnumerator RepeatAttack()
    {
        _isAttackingCoroutineRunning = true;
        while (_isAttack)
        {
            _anim.SetTrigger(AnimationStrings.Attack);
            yield return new WaitForSeconds(_attackInterval); // ���� �ֱ�
        }
        _isAttackingCoroutineRunning = false;
    }

    public void FixedUpdateState()
    {
        // �ʿ� �� ���� ������Ʈ ó��
    }
}
