using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, DistantState
{
    public void EnterState()
    {
        Debug.Log("����Ʈ Attack");
    }
    public void UpdateState()
    {
        Debug.Log("����Ʈ Attack");
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ AttackEND");
    }
}