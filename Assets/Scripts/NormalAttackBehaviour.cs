using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalAttackBehaviour : StateMachineBehaviour
{
    MoveSet moveSet;

    [SerializeField] private float _moveDuration = 0.1f; // 이동하는 데 걸리는 시간 (초)

    private Vector3 _targetPosition;
    
    [SerializeField] private float _elapsedTime; 
    public float _moveForce;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (moveSet == null)
        {
            moveSet = animator.GetComponent<MoveSet>();
        }

        StartMoving(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveForward(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (moveSet != null)
        {
            moveSet.SetNormalAttackUsing(false); // 공격이 실행 끝났음을 MoveSet에 알림
        }
    }
    private void StartMoving(Animator animator)
    {
        // 현재 캐릭터의 방향에 따라 목표 위치를 설정
        Vector3 moveDirection = moveSet.IsFacingLeft ? Vector3.left : Vector3.right;
        _targetPosition = animator.transform.position + moveDirection * _moveForce;
        _elapsedTime = 0f;
    }

    private void MoveForward(Animator animator)
    {
        _elapsedTime += Time.deltaTime;
        float t = _elapsedTime / _moveDuration;
        animator.transform.position = Vector3.Lerp(animator.transform.position, _targetPosition, t);
    }

    

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
