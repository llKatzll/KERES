using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("디스턴트 DeadStart");
    }
    public void UpdateState()
    {
        Debug.Log("디스턴트 Dead");
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 DeadEND");
    }
}
