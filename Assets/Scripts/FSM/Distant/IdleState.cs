using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("디스턴트 Idle Start");
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
