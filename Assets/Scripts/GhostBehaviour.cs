using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : StateMachineBehaviour
{
    Ghost ghost;
    MoveSet moveSet;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveSet = animator.GetComponent<MoveSet>();
        ghost = animator.gameObject.GetComponent<Ghost>();

        if (moveSet != null)
        {
            moveSet.SetSkillUsing(true); // 애니메이션이 실행 중임을 MoveSet에 알림
        }

        if (ghost != null)
        {
            ghost.makeGhost = true;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (moveSet != null)
        {
            moveSet.SetSkillUsing(false); // 애니메이션이 종료되었음을 MoveSet에 알림
        }

        if (ghost != null)
        {
            ghost.makeGhost = false;
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
