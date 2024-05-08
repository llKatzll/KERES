using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, DistantState
{

    Animator _anim;


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

        _anim.SetBool(AnimationStrings.Attack, true);
    }

    public void FixedUpdateState()
    {
        
    }
}

