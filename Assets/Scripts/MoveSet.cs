using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveSet : MonoBehaviour
{
    //step 1. move, jump, dash
    //step 2. pointed attack, rmb throw knife
    //step 3. 
    //step 4.
    //step 5.
    //step 6.
    //step 7.
    private KeyStrokeSystem keyStroke;

    Rigidbody2D rigid;
    BoxCollider2D box;
    Transform tns;
    Animator anim;
    DirectionCheck directionCheck;

    [Header("BaseStat")]
    public float _heatlh = 100f;

    [Header("Speed")]
    public float _moveSpeed;
    public float _jumpPower;
    public float _dashPower;
    public float _dashDuration;

    [Header("GroundCheck")]
    public bool _isGround = true;
    static float _originalGravityScale;


    private Vector2 moveInput;
    public LayerMask groundLayer;

    private void Awake()
    {
        FindObjectOfType<KeyStrokeSystem>().OnCommandInput.AddListener(OnCommandInput);

        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        keyStroke = GetComponent<KeyStrokeSystem>();
        anim = GetComponent<Animator>();
        directionCheck = GetComponent<DirectionCheck>();

        if (directionCheck == null)
        {
            // 만약 DirectionCheck 컴포넌트가 없다면 오류를 출력합니다.
            Debug.LogError("DirectionCheck 컴포넌트를 찾을 수 없습니다.");
        }

        _originalGravityScale = rigid.gravityScale;
    }

    #region 움직임
    public void Moving()
    {
        float x = Input.GetAxisRaw("Horizontal");

        // x 값이 0이 아니면 이동
        if (x != 0f)
        {
            anim.SetBool(AnimationStrings.IsMove, true);
            Vector2 moveDirection = new Vector2(x, 0f).normalized;
            transform.Translate(moveDirection * _moveSpeed * Time.deltaTime);

            moveInput = new Vector2(-x, 0f);
            SetFacingDirection(moveInput);
        }
        else
        {
            anim.SetBool(AnimationStrings.IsMove, false);
        }
    }
    #endregion


    #region 점프
    public void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && directionCheck.IsGrounded)
        {
            Debug.Log("Jumped");
            anim.SetTrigger(AnimationStrings.Jump);
            rigid.velocity = new Vector2(rigid.velocity.x, _jumpPower);
        }
    }
    #endregion

    #region 대쉬
    public void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(mousePosition);

            Vector2 playerPosition = transform.position;

            Vector2 dashDirection = (mousePosition - playerPosition).normalized;

            Debug.Log("Now Dashing");
            playerPosition = Vector2.Lerp(playerPosition, dashDirection, _dashDuration);

            anim.SetTrigger(AnimationStrings.Dash);

            StartCoroutine(ResetGravity());
        }
    }
    #endregion

    #region 바라보는 방향
    [SerializeField]
    private bool _isFacingRight = true;
    public bool isFacingRight
    {
        get { return _isFacingRight; }
        private set
        {
            if (_isFacingRight != value)
            {
                _isFacingRight = value;
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            isFacingRight = false;
        }
    }
    #endregion

    #region 커맨드 입력 받음
    public void OnCommandInput(Ecommands ecommands)
    {
        Debug.Log(message: "커맨드 입력 받음" + ecommands);
        Debug.Log(message: "여기서 Switch문 사용해서 원하는 애니메이션 재생");

        switch (ecommands)
        {
            case Ecommands.ASDQ:
                //으어으어으어어ㄴ앙랄라ㅏㅏ가낙ㄷ가당호오호호홍ㅇ
                Debug.Log("ASDQ!");
                break;
            case Ecommands.WADQ:
                //이아런아런ㅇㄹ여따가 기술 썼을때 그런ㄱ 것좀 서주저얼어억ㄱ
                Debug.Log("WADQ!");
                break;

        }
    }
    #endregion

    private void FixedUpdate()
    {
        Moving();
    }

    private void Update()
    {
        Dashing();
        Jumping();
    }

    #region 중력 초기화
    IEnumerator ResetGravity()
    {
        yield return new WaitForSeconds(_dashDuration);
        rigid.gravityScale = _originalGravityScale;
    }
    #endregion
}
