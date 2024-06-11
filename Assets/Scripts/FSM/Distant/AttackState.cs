using System.Collections;
using UnityEngine;

public class AttackState : MonoBehaviour, DistantState
{
    Animator _anim;
    Distant _distant;
    public bool _isAttack = false;
    [Header("Distant Attack Boolean")]
    
    public bool _isAttackingCoroutineRunning = false; // 코루틴 실행 여부를 확인하는 플래그

    [Header("Distant Attack figure")]
    [SerializeField] private float _attackInterval;

    public void EnterState()
    {
        Debug.Log("디스턴트 AttackStart");
        _anim = GetComponent<Animator>();
        _distant = GetComponent<Distant>();
        _anim.SetBool(AnimationStrings.IsMove, false); //이동 스테이트의 애니메이션 false
        if (!_isAttackingCoroutineRunning)
        {
            StartCoroutine(RepeatAttack());
        }
    }

    public void ExitState()
    {
        Debug.Log("디스턴트 AttackEND");
        _isAttack = false;
        
    }

    public void UpdateState()
    {
        Debug.Log("디스턴트 Attack");

        // UpdateState에서 별도로 반복 공격을 처리할 필요 없음
        // 코루틴에서 반복 공격 처리
    }

    IEnumerator RepeatAttack()
    {
        _isAttackingCoroutineRunning = true;
        while (_isAttack)
        {
            _anim.SetTrigger(AnimationStrings.Attack);
            yield return new WaitForSeconds(_attackInterval); // 공격 주기
        }
        _isAttackingCoroutineRunning = false;
    }

    public void FixedUpdateState()
    {
        // 필요 시 물리 업데이트 처리
    }
}
