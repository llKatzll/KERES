using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("����Ʈ HittedStart");
    }
    public void UpdateState()
    {
        Debug.Log("����Ʈ Hitted");
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ HittedEND");
    }
}
