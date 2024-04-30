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
    //CurrentState프로퍼티는 현재 적 AI가 가지고 있는 상태를 저장한다
    public DistantState CurrentState { get; set; }

    //위 함수는 호출될때 newState값으로 상태를 변환하는 코드다.
    public void Transition(DistantState newState)
    {
        //현재 상태가 null이 아니면, 현재 상태의 ExitState 메서드를 호출한다
        if (CurrentState != null)
        {
            CurrentState.ExitState();
        }
        //새로운 상태를 CurrentState 프로퍼티에 할당한다
        CurrentState = newState;

        //새로운 상태의 EnterState 메서드를 호출하여 상태를 시작한다
        CurrentState.EnterState();
    }

}