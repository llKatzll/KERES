using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("디스턴트 Chase");
    }
    public void UpdateState()
    {
        Debug.Log("디스턴트 Chase");
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 ChaseEND");
    }
}
