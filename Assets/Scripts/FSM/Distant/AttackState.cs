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

        //if(!_isAttack)
        //{
            _anim.SetTrigger(AnimationStrings.Attack);
        //    _isAttack = true;
        //}
    }

    public void FixedUpdateState()
    {
        
    }
}

