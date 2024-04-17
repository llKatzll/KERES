using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStroke : MonoBehaviour
{
    private KeyStrokeSystem keyStroke;

    private void Awake()
    {
        keyStroke = GetComponent<KeyStrokeSystem>();
        FindObjectOfType<KeyStrokeSystem>().OnCommandInput.AddListener(OnCommandInput);
    }

    #region Ŀ�ǵ� �Է� ����
    public void OnCommandInput(Ecommands ecommands)
    {
        Debug.Log(message: "Ŀ�ǵ� �Է� ����" + ecommands);
        Debug.Log(message: "���⼭ Switch�� ����ؼ� ���ϴ� �ִϸ��̼� ���");

        switch (ecommands)
        {
            case Ecommands.ASDQ:
                
                break;
            case Ecommands.WADQ:
                
                break;
            case Ecommands.WASDWWQ:
                
                break;
            case Ecommands.SSDQ:
                
                break;
            case Ecommands.SSADQ:
                
                break;
            case Ecommands.ADADQ:
                
                break;
            case Ecommands.QWEASDQ:
               
                break;
            case Ecommands.SDQ:
                
                break;
            case Ecommands.ASE:
                
                break;
            case Ecommands.ADDQ:
                
                break;
            case Ecommands.ASDASDQ:
                
                break;
            case Ecommands.DSADDQ:
                
                break;
            case Ecommands.DASQ:
                
                break;
            case Ecommands.SAX:
                
                break;
        }
    }
    #endregion

    #region ��ų���� ���ձ���
    void cmd_SAX()
    {
        Debug.Log("SAX!");
    }

    void cmd_DASQ()
    {
        Debug.Log("DASQ!");
    }

    void cmd_ASDQ()
    {
        Debug.Log("ASDQ!");
    }

    void cmd_WADQ()
    {
        Debug.Log("WADQ!");
    }

    void cmd_SSADQ()
    {
        Debug.Log("SSADQ!");
    }

    void cmd_ASDASDQ()
    {
        Debug.Log("ASDASDQ!");
    }

    void cmd_QWEASDQ()
    {
        Debug.Log("QWEASDQ!");
    }

    void cmd_ASE()
    {
        Debug.Log("ASE!");
    }

    void cmd_SDQ()
    {
        Debug.Log("SDQ!");
    }

    void cmd_SSDQ()
    {
        Debug.Log("SSDQ!");
    }

    void cmd_ADDQ()
    {
        Debug.Log("ADDQ!");
    }

    void cmd_DSADDQ()
    {
        Debug.Log("DSADDQ!");
    }

    void cmd_WASDWWQ()
    {
        Debug.Log("WASDWWQ!");
    }

    void cmd_ADADQ()
    {
        Debug.Log("ADADQ!");
    }
    #endregion
}
