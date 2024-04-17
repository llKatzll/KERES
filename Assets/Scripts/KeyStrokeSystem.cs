using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;


//ASDQ, //낫 휘두르기 - 전방(에어리얼)
//WADQ, //낫 휘두르기 - 하단(띄움)
//WASDWWQ, //궁극기1 
//SSDQ, //스텍 1 소모, 돌진베기(관통)
//SSADQ, //스텍 2 소모, 나이프 뿌리기 (표식)
//ADADQ, //반격기
//QWEASDQ, //궁극기2
//SDQ, //스텍 1 소모, 나이프 던지기 (표식)
//ASE, //2회 사용 가능, 발걸고 강펀치
//ADDQ, //사선베며 내려오기(관통)
//ASDASDQ, //낫 휘두르기 - 강하게
//DASQ, //돌려내려찍기 (뒤에 Q로 차징 가능)
//SAX, //리볼버

public enum Ecommands
{
    ASDQ,
    WADQ,
    WASDWWQ,
    SSDQ,
    SSADQ,
    ADADQ,
    QWEASDQ,
    SDQ,
    ASE,
    ADDQ,
    ASDASDQ,
    DSADDQ,
    DASQ,
    SAX,
}


public class KeyStrokeSystem : MonoBehaviour
{

    public UnityEvent<Ecommands> OnCommandInput;

    // 플레이어로부터의 입력을 저장할 큐
    Queue<KeyCode> _keyQueue = new Queue<KeyCode>();

    // 검사할 커맨드 패턴 정의
    public KeyCode[] ASDASDQ = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Q };
    public KeyCode[] ASDQ = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Q };
    public KeyCode[] SDQ = { KeyCode.S, KeyCode.D, KeyCode.Q };
    public KeyCode[] QWEASDQ = { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Q };
    public KeyCode[] WASDWWQ = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.W, KeyCode.W, KeyCode.Q };
    public KeyCode[] DSADDQ = { KeyCode.D, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.D, KeyCode.Q };
    public KeyCode[] SSDQ = { KeyCode.S, KeyCode.S, KeyCode.D, KeyCode.Q };
    public KeyCode[] ASE = { KeyCode.A, KeyCode.S, KeyCode.E };
    public KeyCode[] SAX = { KeyCode.S, KeyCode.A, KeyCode.X };
    public KeyCode[] WADQ = { KeyCode.W, KeyCode.A, KeyCode.D, KeyCode.Q };
    public KeyCode[] SSADQ = { KeyCode.S, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Q };
    public KeyCode[] ADADQ = { KeyCode.A, KeyCode.D, KeyCode.A, KeyCode.D, KeyCode.Q };
    public KeyCode[] DASQ = { KeyCode.D, KeyCode.A, KeyCode.S, KeyCode.Q };


    // 입력 받은 후 일정 시간 동안 대기할 시간 설정
    [SerializeField] private float timeToElapse = 1;
    float timer = 0;

    private StringBuilder sb = new StringBuilder();



    void Update()
    {
        // 플레이어 입력 받기
        GetInput();

        // 시간 측정
        timer += Time.deltaTime;
        // 설정한 시간이 지나면 입력 데이터 초기화
        if (timer > timeToElapse && _keyQueue.Count > 0)
        {
            _keyQueue.Clear();
            timer = 0;
        }

        // 입력 데이터가 일정량 이상이면 가장 오래된 데이터부터 제거
        if (_keyQueue.Count > 100)
        {
            _keyQueue.Dequeue();
        }

        // 큐에 저장된 키 입력 로그 출력
        if (_keyQueue.Count > 0)
        {
            sb.Clear();
            foreach (KeyCode key in _keyQueue)
            {
                string keyString = string.Join("", _keyQueue.Select(key => key.ToString()));
                Debug.Log(keyString);
            }
        }

        // 입력된 커맨드 검사
        CheckCommand();
    }

    public void CheckCommand()
    {
        // 더 긴 커맨드를 먼저 검사하여 맞는 경우 해당 커맨드 실행
        if (CheckCommand(QWEASDQ))
        {
            OnCommandInput.Invoke(Ecommands.QWEASDQ);
        }
        else if (CheckCommand(ASDASDQ))
        {
            OnCommandInput.Invoke(Ecommands.ASDASDQ);
        }
        else if (CheckCommand(ASDQ))
        {
            OnCommandInput.Invoke(Ecommands.ASDQ);
        }
        else if (CheckCommand(SDQ))
        {
            OnCommandInput.Invoke(Ecommands.SDQ);
        }
        else if (CheckCommand(DSADDQ))
        {
            OnCommandInput.Invoke(Ecommands.DSADDQ);
        }
        else if (CheckCommand(ADADQ))
        {
            OnCommandInput.Invoke(Ecommands.ADADQ);
        }
        else if (CheckCommand(SSADQ))
        {
            OnCommandInput.Invoke(Ecommands.SSADQ);
        }
        else if (CheckCommand(SSDQ))
        {
            OnCommandInput.Invoke(Ecommands.SSDQ);
        }
        else if (CheckCommand(WASDWWQ))
        {
            OnCommandInput.Invoke(Ecommands.WASDWWQ);
        }
        else if (CheckCommand(DASQ))
        {
            OnCommandInput.Invoke(Ecommands.DASQ);
        }
        else if (CheckCommand(WADQ))
        {
            OnCommandInput.Invoke(Ecommands.WADQ);
        }
        else if (CheckCommand(ASE))
        {
            OnCommandInput.Invoke(Ecommands.ASE);
        }
        else if (CheckCommand(SAX))
        {
            OnCommandInput.Invoke(Ecommands.SAX);
        }
        
    }

    // 입력된 커맨드가 정의된 커맨드와 일치하는지 검사
    bool CheckCommand(KeyCode[] command)
    {
        // 입력된 데이터가 커맨드 길이보다 짧으면 false 반환
        if (_keyQueue.Count < command.Length)
        {
            return false;
        }

        // 큐를 배열로 변환하여 검사 용이하게 함
        KeyCode[] inputs = _keyQueue.ToArray();

        // 입력된 커맨드의 마지막 부분부터 검사하여 일치하는지 확인
        for (int i = inputs.Length - command.Length, j = 0; i < inputs.Length; i++, j++)
        {
            if (inputs[i] != command[j])
            {
                return false;
            }
        }

        // 커맨드가 일치하면 큐를 초기화하고 true 반환
        _keyQueue.Clear();
        timer = 0;
        return true;
    }

    // 플레이어로부터의 입력을 받아 큐에 저장
    private void GetInput()
    {
        KeyCode[] keysToCheck = { KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S, KeyCode.Q, KeyCode.E, KeyCode.X };

        foreach (KeyCode key in keysToCheck)
        {
            if (Input.GetKeyDown(key))
            {
                _keyQueue.Enqueue(key);
            }
        }
    }
}
