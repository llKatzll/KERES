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

    //TODO : �� �ڵ忡�� "���⿡ ChaseState���� ��ȯ�� ���� �ڵ� �ۼ�" �κп��� �÷��̾ �־����� 
    //ChaseState���� ��ȯ�� ���� �ڵ带 �ۼ��ϸ� �˴ϴ�. �̸� �����ϱ� ���ؼ��� EnemyMoveStopBehaviour Ŭ������ Enemy�� ������ �����;� �� ���Դϴ�. 
    //�̸� ���� �ʿ��� ������ �Ͽ��� �մϴ�. �׸��� �� Ŭ���������� ���� ��ȯ�� �����ϴ� StateContext�� ����Ǿ�� �մϴ�. �̰��� �����ؼ� �ʿ��� ������ �غ�����.
}
