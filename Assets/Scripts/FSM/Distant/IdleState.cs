using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : MonoBehaviour, DistantState
{
    Animator _anim;
    Distant _distant;
    AttackState _attackState;

    public void EnterState()
    {
        Debug.Log("����Ʈ Idle Start");
        _anim = GetComponent<Animator>();
        _distant = GetComponent<Distant>();
        _attackState = GetComponent<AttackState>();
        _anim.SetBool(AnimationStrings.IsMove, false);
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ IdleEND");
    }
    public void UpdateState()
    {
        Debug.Log("����Ʈ Idle");
    }
    public void FixedUpdateState()
    {

    }
}
