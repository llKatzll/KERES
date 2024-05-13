using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, DistantState
{

    Animator _anim;

    //private bool _isAttack = false;

    public void EnterState()
    {
        Debug.Log("����Ʈ AttackStart");
        _anim = GetComponent<Animator>();
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ AttackEND");
    }

    public void UpdateState()
    {
        Debug.Log("����Ʈ Attack");

        _anim.SetTrigger(AnimationStrings.Attack); //TODO : ���̳ʹķ����ͷ� 2�ʸ��� �ǰԲ�? || Time.deltatime���� �����ֱ⸶�� ȣ���� �ǰԲ�, rifle�� �߻� �Լ��� ����
    }

    public void FixedUpdateState()
    {
        
    }
}

