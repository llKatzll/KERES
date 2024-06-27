using System.Collections;
using UnityEngine;

public class AttackState : MonoBehaviour, DistantState
{
    Animator _anim;
    Distant _distant;
    ChaseState _chaseState;
    [Header("Distant Attack Boolean")]
    
    public bool _isAttackingCoroutineRunning = false; // �ڷ�ƾ ���� ���θ� Ȯ���ϴ� �÷���

    [Header("Distant Attack figure")]
    [SerializeField] private float _attackInterval;

    public void EnterState()
    {
        Debug.Log("����Ʈ AttackStart");
        _anim = GetComponent<Animator>();
        _distant = GetComponent<Distant>();
        _chaseState = GetComponent<ChaseState>();
        _anim.SetBool(AnimationStrings.IsMove, false); //�̵� ������Ʈ�� �ִϸ��̼� false
        
        
    }

    public void ExitState()
    {
        Debug.Log("����Ʈ AttackEND");
    }

    public void UpdateState()
    {
        Debug.Log("����Ʈ Attack");

        // UpdateState���� ������ �ݺ� ������ ó���� �ʿ� ����
        // �ڷ�ƾ���� �ݺ� ���� ó��
    }

    IEnumerator RepeatAttack()
    {
        _anim.SetTrigger(AnimationStrings.Attack);
        Debug.Log("Ȯ��");
        yield return new WaitForSeconds(_attackInterval); // ���� �ֱ�
    }



    public void FixedUpdateState()
    {
        // �ʿ� �� ���� ������Ʈ ó��
    }
}
