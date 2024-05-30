using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingState : MonoBehaviour, DistantState
{
    private Animator _anim;
    private Distant _distant;

    public void Awake()
    {
        _anim = GetComponent<Animator>();
        _distant = GetComponent<Distant>();

        if (_distant == null)
        {
            Debug.LogError("HittingState: _distant is null.");
        }
    }

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
        if (_distant.health <= 0)
        {
            _distant.UpdateState(EState.Dead);
        }
    }

    public void FixedUpdateState()
    {
        // 물리 업데이트 로직 (필요한 경우)
    }
}
