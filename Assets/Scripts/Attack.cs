using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator _anim;

    Distant _distant;

    EState _currentState;

    private StateContext _stateContext;

    private Coroutine attackCoroutine;

    [SerializeField] private bool _isAttacking = false; // ���� ���� ������ ����
    private bool _isIdle = true; // ��� ���� ����
    private float _lastAttackTime; // ������ ���� �ð�

    //[SerializeField] private BoxCollider2D[] _hitboxes;

    [Header("Time")]
    [SerializeField] private float _waitTime = 0.3f; // ���� ��� �ð�

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _distant = GetComponent<Distant>();
        _stateContext = new StateContext();
    }

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isAttacking)
            {
                StartAttackCoroutine();
            }
            StopAttackCoroutine();
            //else
            //{
            // �̹� ���� ���̸� Coroutine�� �����ϰ� ������մϴ�.

            //    StartAttackCoroutine();
            //}
        }
    }

    void StartAttackCoroutine() //���ݽ���
    {
        _isAttacking = true;
        attackCoroutine = StartCoroutine(AttackRoutine());
    }

    void StopAttackCoroutine() //��������
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        _isAttacking = false;
    }


    IEnumerator AttackRoutine()
    {
        _anim.SetTrigger("AttackA"); // A �ִϸ��̼� Ʈ���� ����
        Debug.Log("1��° ����");

        // Ŭ�� ������ ��ٸ��ϴ�.
        yield return new WaitForSeconds(_waitTime);

        // �ٽ� �� �� Ŭ���� �����Ǹ�
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger("AttackB"); // B �ִϸ��̼� Ʈ���� ����
            Debug.Log("2��° ����");

            // Ŭ�� ������ ��ٸ��ϴ�.
            yield return new WaitForSeconds(_waitTime);

            // �ٽ� �� �� Ŭ���� �����Ǹ�
            if (Input.GetMouseButtonDown(0))
            {
                _anim.SetTrigger("AttackC"); // C �ִϸ��̼� Ʈ���� ����
                Debug.Log("3��° ����");
            }
        }

        // ���� �ð� ���� �ٽ� Ŭ���� �������� ������ Idle�� ���ư��ϴ�.
        yield return new WaitForSeconds(_waitTime);

        // Idle �ִϸ��̼� ����
        _isAttacking = false;
    }
}
