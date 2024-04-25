using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStroke : MonoBehaviour
{
    private KeyStrokeSystem keyStroke;
    private MoveSet moveSet;
    private MousePositionLocater mousePosLocater;
    private Animator animator;
    private Ghost ghost;
    private KeresStatus _keres;

    private Rigidbody2D _rigid;

    private void Awake()
    {
        keyStroke = GetComponent<KeyStrokeSystem>();
        animator = GetComponent<Animator>();
        moveSet = GetComponent<MoveSet>();
        _rigid = GetComponent<Rigidbody2D>();
        _keres = GetComponent<KeresStatus>();
        keyStroke.OnCommandInput.AddListener(OnCommandInput);
        //FindObjectOfType<KeyStrokeSystem>().OnCommandInput.AddListener(OnCommandInput);
    }

    #region 커맨드 입력 받음
    public void OnCommandInput(Ecommands ecommands)
    {
        Debug.Log(message: "커맨드 입력 받음" + ecommands);
        Debug.Log(message: "여기서 Switch문 사용해서 원하는 애니메이션 재생");

        switch (ecommands)
        {
            case Ecommands.ASDQ:
                cmd_ASDQ();
                break;
            case Ecommands.WADQ:
                cmd_WADQ();
                break;
            case Ecommands.WASDWWQ:
                cmd_WASDWWQ();
                break;
            case Ecommands.SSDQ:
                cmd_SSDQ();
                break;
            case Ecommands.SSADQ:
                cmd_SSADQ();
                break;
            case Ecommands.ADADQ:
                cmd_ADADQ();
                break;
            case Ecommands.QWEASDQ:
                cmd_QWEASDQ();
                break;
            case Ecommands.SDQ:
                cmd_SDQ();
                break;
            case Ecommands.ASE:
                cmd_ASE();
                break;
            case Ecommands.ADDQ:
                cmd_ADDQ();
                break;
            case Ecommands.ASDASDQ:
                cmd_ASDASDQ();
                break;
            case Ecommands.DSADDQ:
                cmd_DSADDQ();
                break;
            case Ecommands.DASQ:
                cmd_DASQ();
                break;
            case Ecommands.DAQ:
                cmd_DAQ();
                break;
            case Ecommands.SAX:
                cmd_SAX();
                break;
        }
    }
    #endregion

    #region 스킬들의 집합구역
    void cmd_SAX()
    {
        Debug.Log("SAX!");
        PlayAnimation("SAX");
        //float _flightLocate = Mathf.Sin(1f); //사인 그래프 이용하여 도약 후 마무리
        if (moveSet.IsFacingLeft)
        {
            _rigid.AddForce(Vector2.left * 10f, ForceMode2D.Impulse);
        }
        else
        {
            _rigid.AddForce(Vector2.right * 10f, ForceMode2D.Impulse);
        }
    }

    void cmd_DASQ()
    {
        Debug.Log("DASQ!");
    }

    void cmd_DAQ()
    {
        Debug.Log("DAQ!");
        _keres._knifeStack++;
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

    void PlayAnimation(string skillName)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 playerPosition = transform.position;

        Vector2 skillDirection = (mousePosition - playerPosition).normalized;

        if (skillDirection.x > 0f)
        {
            moveSet.IsFacingLeft = false;
        }
        else
        {
            moveSet.IsFacingLeft = true;
        }
        animator.Play(skillName);
    }
}
