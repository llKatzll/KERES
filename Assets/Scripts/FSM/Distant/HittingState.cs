using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("����Ʈ HittedStart");
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ HittedEND");
    }
    public void UpdateState()
    {
        Debug.Log("����Ʈ Hitted");
    }
}
