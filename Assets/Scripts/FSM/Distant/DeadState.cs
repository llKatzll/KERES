using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("����Ʈ DeadStart");
    }
    public void UpdateState()
    {
        Debug.Log("����Ʈ Dead");
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ DeadEND");
    }
}
