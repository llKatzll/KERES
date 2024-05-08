using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingState : MonoBehaviour, DistantState
{

    Animator _anim;


    public void EnterState()
    {
        Debug.Log("디스턴트 HittedStart");
        _anim = GetComponent<Animator>();
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 HittedEND");
    }
    public void UpdateState()
    {
        Debug.Log("디스턴트 Hitted");
    }

    public void FixedUpdateState()
    {

    }
}
