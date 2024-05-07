using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("����Ʈ Idle Start");
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
