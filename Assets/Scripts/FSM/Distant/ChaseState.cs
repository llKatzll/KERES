using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("����Ʈ ChaseStart");
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ ChaseEND");
    }
    public void UpdateState()
    {
        Debug.Log("����Ʈ Chase");
    }
}
