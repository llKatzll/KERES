using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingState : MonoBehaviour, DistantState
{

    Animator _anim;


    public void EnterState()
    {
        Debug.Log("����Ʈ HittedStart");
        _anim = GetComponent<Animator>();
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ HittedEND");
    }
    public void UpdateState()
    {
        Debug.Log("����Ʈ Hitted");
    }

    public void FixedUpdateState()
    {

    }
}
