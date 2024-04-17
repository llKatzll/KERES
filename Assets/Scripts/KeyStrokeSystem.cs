using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;


//ASDQ, //�� �ֵθ��� - ����(�����)
//WADQ, //�� �ֵθ��� - �ϴ�(���)
//WASDWWQ, //�ñر�1 
//SSDQ, //���� 1 �Ҹ�, ��������(����)
//SSADQ, //���� 2 �Ҹ�, ������ �Ѹ��� (ǥ��)
//ADADQ, //�ݰݱ�
//QWEASDQ, //�ñر�2
//SDQ, //���� 1 �Ҹ�, ������ ������ (ǥ��)
//ASE, //2ȸ ��� ����, �߰ɰ� ����ġ
//ADDQ, //�缱���� ��������(����)
//ASDASDQ, //�� �ֵθ��� - ���ϰ�
//DASQ, //����������� (�ڿ� Q�� ��¡ ����)
//SAX, //������

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

    // �÷��̾�κ����� �Է��� ������ ť
    Queue<KeyCode> _keyQueue = new Queue<KeyCode>();

    // �˻��� Ŀ�ǵ� ���� ����
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


    // �Է� ���� �� ���� �ð� ���� ����� �ð� ����
    [SerializeField] private float timeToElapse = 1;
    float timer = 0;

    private StringBuilder sb = new StringBuilder();



    void Update()
    {
        // �÷��̾� �Է� �ޱ�
        GetInput();

        // �ð� ����
        timer += Time.deltaTime;
        // ������ �ð��� ������ �Է� ������ �ʱ�ȭ
        if (timer > timeToElapse && _keyQueue.Count > 0)
        {
            _keyQueue.Clear();
            timer = 0;
        }

        // �Է� �����Ͱ� ������ �̻��̸� ���� ������ �����ͺ��� ����
        if (_keyQueue.Count > 100)
        {
            _keyQueue.Dequeue();
        }

        // ť�� ����� Ű �Է� �α� ���
        if (_keyQueue.Count > 0)
        {
            sb.Clear();
            foreach (KeyCode key in _keyQueue)
            {
                string keyString = string.Join("", _keyQueue.Select(key => key.ToString()));
                Debug.Log(keyString);
            }
        }

        // �Էµ� Ŀ�ǵ� �˻�
        CheckCommand();
    }

    public void CheckCommand()
    {
        // �� �� Ŀ�ǵ带 ���� �˻��Ͽ� �´� ��� �ش� Ŀ�ǵ� ����
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

    // �Էµ� Ŀ�ǵ尡 ���ǵ� Ŀ�ǵ�� ��ġ�ϴ��� �˻�
    bool CheckCommand(KeyCode[] command)
    {
        // �Էµ� �����Ͱ� Ŀ�ǵ� ���̺��� ª���� false ��ȯ
        if (_keyQueue.Count < command.Length)
        {
            return false;
        }

        // ť�� �迭�� ��ȯ�Ͽ� �˻� �����ϰ� ��
        KeyCode[] inputs = _keyQueue.ToArray();

        // �Էµ� Ŀ�ǵ��� ������ �κк��� �˻��Ͽ� ��ġ�ϴ��� Ȯ��
        for (int i = inputs.Length - command.Length, j = 0; i < inputs.Length; i++, j++)
        {
            if (inputs[i] != command[j])
            {
                return false;
            }
        }

        // Ŀ�ǵ尡 ��ġ�ϸ� ť�� �ʱ�ȭ�ϰ� true ��ȯ
        _keyQueue.Clear();
        timer = 0;
        return true;
    }

    // �÷��̾�κ����� �Է��� �޾� ť�� ����
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
