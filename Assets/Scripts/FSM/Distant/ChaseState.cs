using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour, DistantState
{
    [SerializeField] private Transform _playerLocation;
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
        Debug.Log("�����̵�");
        transform.position = _playerLocation.position;
    }
}
