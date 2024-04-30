using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour, DistantState
{
    [SerializeField] private Transform _playerLocation;
    public void EnterState()
    {
        Debug.Log("디스턴트 ChaseStart");
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 ChaseEND");
    }
    public void UpdateState()
    {
        Debug.Log("괴물이되");
        transform.position = _playerLocation.position;
    }
}
