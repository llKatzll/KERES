using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("디스턴트 HittedStart");
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 HittedEND");
    }
    public void UpdateState()
    {
        Debug.Log("디스턴트 Hitted");
    }
}
