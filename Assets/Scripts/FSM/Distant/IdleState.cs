using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : MonoBehaviour, DistantState
{
    Animator _anim;
    Distant _distant;
    AttackState _attackState;

    [SerializeField] private float _lookVisionX;
    [SerializeField] private float _lookVisionY;
    [SerializeField] private LayerMask _whatIsPlayer;

    public void EnterState()
    {
        Debug.Log("디스턴트 Idle Start");
        _anim = GetComponent<Animator>();
        _distant = GetComponent<Distant>();
        _attackState = GetComponent<AttackState>();
        _anim.SetBool(AnimationStrings.IsMove, false);
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 IdleEND");
    }
    public void UpdateState()
    {
        Debug.Log("디스턴트 Idle");
        ChaseVision();
    }
    public void FixedUpdateState()
    {

    }

    void ChaseVision()
    {
        bool _lookHit = Physics2D.BoxCast(transform.position, new Vector2(_lookVisionX, _lookVisionY), 0f, Vector2.zero, 0, _whatIsPlayer);
        //시야 확인 후 시야에 들어올 시 추격함
        if (_lookHit && !_attackState._isAttackingCoroutineRunning)
        {
            _lookVisionX = _lookVisionX * 2.5f;
            _lookVisionY = _lookVisionY * 2.5f;
            _distant.UpdateState(EState.Chase);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.red;
        DrawBox(transform.position, new Vector2(_lookVisionX, _lookVisionY));
    }

    void DrawBox(Vector3 center, Vector2 size)
    {
        Vector2 halfSize = size / 2f;

        Vector3 topLeft = center + new Vector3(-halfSize.x, halfSize.y);
        Vector3 topRight = center + new Vector3(halfSize.x, halfSize.y);
        Vector3 bottomRight = center + new Vector3(halfSize.x, -halfSize.y);
        Vector3 bottomLeft = center + new Vector3(-halfSize.x, -halfSize.y);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
