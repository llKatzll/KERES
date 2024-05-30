using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : MonoBehaviour, DistantState
{
    Animator _anim;

    public void EnterState()
    {
        Debug.Log("디스턴트 Idle Start");
        _anim = GetComponent<Animator>();

        _anim.SetBool(AnimationStrings.IsMove, false);
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 IdleEND");
    }
    public void UpdateState()
    {
        Debug.Log("디스턴트 Idle");
    }
    public void FixedUpdateState()
    {

    }
}
