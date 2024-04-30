using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EState
{
    Idle,
    Chase,
    Attack,
    Hitted,
    Dead,
    Max,
}


public class StateContext
{
    //CurrentState������Ƽ�� ���� �� AI�� ������ �ִ� ���¸� �����Ѵ�
    public DistantState CurrentState { get; set; }

    //�� �Լ��� ȣ��ɶ� newState������ ���¸� ��ȯ�ϴ� �ڵ��.
    public void Transition(DistantState newState)
    {
        //���� ���°� null�� �ƴϸ�, ���� ������ ExitState �޼��带 ȣ���Ѵ�
        if (CurrentState != null)
        {
            CurrentState.ExitState();
        }
        //���ο� ���¸� CurrentState ������Ƽ�� �Ҵ��Ѵ�
        CurrentState = newState;

        //���ο� ������ EnterState �޼��带 ȣ���Ͽ� ���¸� �����Ѵ�
        CurrentState.EnterState();
    }

}