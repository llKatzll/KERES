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
        Debug.Log("����Ʈ HittedStart");
    }

    public void ExitState()
    {
        Debug.Log("����Ʈ HittedEND");
    }

    public void UpdateState()
    {
        Debug.Log("����Ʈ Hitted");
        if (_distant.health <= 0)
        {
            _distant.UpdateState(EState.Dead);
        }
    }

    public void FixedUpdateState()
    {
        // ���� ������Ʈ ���� (�ʿ��� ���)
    }
}
