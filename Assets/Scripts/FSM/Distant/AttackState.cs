using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("디스턴트 AttackStart");
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 AttackEND");
    }
    public void UpdateState()
    {
        Debug.Log("디스턴트 Attack");
    }

    public void FixedUpdateState()
    {
        
    }
}

