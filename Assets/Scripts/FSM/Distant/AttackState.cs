using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, DistantState
{

    Animator _anim;

    //private bool _isAttack = false;

    public void EnterState()
    {
        Debug.Log("디스턴트 AttackStart");
        _anim = GetComponent<Animator>();
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 AttackEND");
    }

    public void UpdateState()
    {
        Debug.Log("디스턴트 Attack");

        _anim.SetTrigger(AnimationStrings.Attack); //TODO : 아이너뮬레이터로 2초마다 되게끔? || Time.deltatime으로 일정주기마다 호출이 되게끔, rifle의 발사 함수를 참고
    }

    public void FixedUpdateState()
    {
        
    }
}

