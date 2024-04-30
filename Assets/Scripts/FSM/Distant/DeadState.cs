using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : MonoBehaviour, DistantState
{
    [SerializeField] private Transform _playerLocation;
    public void EnterState()
    {
        Debug.Log("디스턴트 DeadStart");
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 DeadEND");
    }
    public void UpdateState()
    {
        Debug.Log("디스턴트 Dead, 존나 붙어다닐거야존나 붙어다닐거야존나 붙어다닐거야존나 붙어다닐거야존나 붙어다닐거야");
        transform.position = _playerLocation.position;
    }

}
