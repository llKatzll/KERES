using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    private Distant _distant;

    [Header("CheckPlayer : Attack")]
    [SerializeField] private float _attackVisionX;
    [SerializeField] private float _attackVisionY;

    [Header("CheckPlayer : Attack")]
    [SerializeField] private float _lookVisionX;
    [SerializeField] private float _lookVisionY;

    [SerializeField] private LayerMask _whatIsPlayer;

    private void IsKeresNearby()
    {
        bool _attackLookHit = Physics2D.BoxCast(transform.position, new Vector2(_attackVisionX, _attackVisionY), 0f, Vector2.zero, 0, _whatIsPlayer);

        if (_attackLookHit)
        {
            _distant.UpdateState(EState.Attack);
        }
        else if (!_attackLookHit)
        {
            _distant.UpdateState(EState.Chase);
        }
    }

    void ChaseVision()
    {
        bool _lookHit = Physics2D.BoxCast(transform.position, new Vector2(_lookVisionX, _lookVisionY), 0f, Vector2.zero, 0, _whatIsPlayer);
        //시야 확인 후 시야에 들어올 시 추격함
        if (_lookHit)
        {
            _lookVisionX = _lookVisionX * 2.5f;
            _lookVisionY = _lookVisionY * 2.5f;
            _distant.UpdateState(EState.Chase);
        }
        else if (!_lookHit)
        {
            _distant.UpdateState(EState.Idle);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.blue;
        DrawBox(transform.position, new Vector2(_attackVisionX, _attackVisionY));
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
