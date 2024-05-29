using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStopBehaviour : StateMachineBehaviour
{
    MoveSet moveSet;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveSet = animator.GetComponent<MoveSet>();

        if (moveSet != null)
        {
            moveSet.SetNormalAttackUsing(true); // 공격이 실행 중임을 MoveSet에 알림
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (moveSet != null)
        {
            moveSet.SetNormalAttackUsing(false); // 공격이 실행 끝났음을 MoveSet에 알림
        }
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
