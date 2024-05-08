using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveStopBehaviour : StateMachineBehaviour
{
    private Distant _distant;

    private EState _currentState;

    private StateContext _stateContext;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool(AnimationStrings.Attack))
        {
            return;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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

    //TODO : 위 코드에서 "여기에 ChaseState로의 전환을 막는 코드 작성" 부분에는 플레이어가 멀어져서 
    //ChaseState로의 전환을 막는 코드를 작성하면 됩니다. 이를 구현하기 위해서는 EnemyMoveStopBehaviour 클래스가 Enemy의 참조를 가져와야 할 것입니다. 
    //이를 위해 필요한 수정을 하여야 합니다. 그리고 이 클래스에서는 상태 전환을 관리하는 StateContext와 연결되어야 합니다. 이것을 참고해서 필요한 수정을 해보세요.
}
