using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("����Ʈ AttackStart");
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ AttackEND");
    }
    public void UpdateState()
    {
        Debug.Log("����Ʈ Attack");
    }

    public void FixedUpdateState()
    {
        
    }
}

