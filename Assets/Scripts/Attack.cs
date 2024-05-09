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

    [SerializeField] private bool _isAttacking = false; // 현재 공격 중인지 여부
    private bool _isIdle = true; // 대기 상태 여부
    private float _lastAttackTime; // 마지막 공격 시간

    //[SerializeField] private BoxCollider2D[] _hitboxes;

    [Header("Time")]
    [SerializeField] private float _waitTime = 0.3f; // 공격 대기 시간

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
            // 이미 공격 중이면 Coroutine을 중지하고 재시작합니다.

            //    StartAttackCoroutine();
            //}
        }
    }

    void StartAttackCoroutine() //공격실행
    {
        _isAttacking = true;
        attackCoroutine = StartCoroutine(AttackRoutine());
    }

    void StopAttackCoroutine() //공격중지
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        _isAttacking = false;
    }


    IEnumerator AttackRoutine()
    {
        _anim.SetTrigger("AttackA"); // A 애니메이션 트리거 설정
        Debug.Log("1번째 공격");

        // 클릭 간격을 기다립니다.
        yield return new WaitForSeconds(_waitTime);

        // 다시 한 번 클릭이 감지되면
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger("AttackB"); // B 애니메이션 트리거 설정
            Debug.Log("2번째 공격");

            // 클릭 간격을 기다립니다.
            yield return new WaitForSeconds(_waitTime);

            // 다시 한 번 클릭이 감지되면
            if (Input.GetMouseButtonDown(0))
            {
                _anim.SetTrigger("AttackC"); // C 애니메이션 트리거 설정
                Debug.Log("3번째 공격");
            }
        }

        // 일정 시간 내에 다시 클릭이 감지되지 않으면 Idle로 돌아갑니다.
        yield return new WaitForSeconds(_waitTime);

        // Idle 애니메이션 설정
        _isAttacking = false;
    }
}
