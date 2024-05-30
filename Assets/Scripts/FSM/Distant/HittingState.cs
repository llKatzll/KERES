using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingState : MonoBehaviour, DistantState
{

    Animator _anim;
    Distant _distant;


    public void EnterState()
    {
        Debug.Log("디스턴트 HittedStart");
        _anim = GetComponent<Animator>();
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 HittedEND");
    }
    public void UpdateState()
    {
        Debug.Log("디스턴트 Hitted");


    }

    public void TakeDamage(float damage)
    {
        _distant.health -= damage;
        if (_distant.health <= 0)
        {
            _distant.UpdateState(EState.Dead);
        }
    }

    public void ApplyKnockback(Vector2 hitPosition, float knockbackPower)
    {
        Vector2 knockbackDirection = (transform.position - (Vector3)hitPosition).normalized;
        GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);
    }

    public void FixedUpdateState()
    {

    }
}
