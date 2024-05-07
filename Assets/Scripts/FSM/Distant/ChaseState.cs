using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour, DistantState
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;

    Animator _anim;

    public void EnterState()
    {
        Debug.Log("디스턴트 ChaseStart");
        _anim = GetComponent<Animator>();
    }
    public void ExitState()
    {
        Debug.Log("디스턴트 ChaseEND");
    }
    public void UpdateState()
    {
        
    }
    public void FixedUpdateState()
    {
        Debug.Log("괴물이되");
        if (_target != null)
        {
            // 적이 플레이어를 향해 이동하도록 방향 벡터를 계산
            Vector2 direction = (_target.position - transform.position).normalized;

            // 적의 현재 위치를 플레이어 방향으로 조금씩 이동
            transform.Translate(direction * _moveSpeed * Time.deltaTime);

            //_anim.SetBool(AnimationStrings.IsMove, true);

            // 적이 플레이어를 바라보도록 방향을 설정
            if (direction.x > 0)
            {
                // 플레이어가 오른쪽에 있는 경우
                transform.localScale = new Vector2(-2.7f, 2.7f);// 적을 좌우 반전하여 오른쪽을 바라보게 함
            }
            else
            {
                // 플레이어가 왼쪽에 있는 경우
                transform.localScale = new Vector2(2.7f, 2.7f); // 적을 좌우 반전하지 않고 왼쪽을 바라보게 함
            }
        }
    }
}
