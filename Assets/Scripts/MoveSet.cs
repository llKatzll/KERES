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
    [SerializeField] private float _heatlh = 100f;

    [Header("Speed & Dash")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _dashPower;
    [SerializeField] private float _dashDuration;

    [Header("GroundCheck")]
    [SerializeField] private bool _isGround = true;
    [SerializeField] static float _originalGravityScale;

    [Header("CoolDown About Dash")]
    [SerializeField] private float _dashCoolDown = 2f;

    private Vector2 moveInput;
    private LayerMask groundLayer;
    [SerializeField] private bool _isFacingRight = false;

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
            moveInput = new Vector2(x, 0f);
            SetFacingDirection(moveInput);
            Vector2 moveDirection = new Vector2(x, 0f).normalized;
            transform.Translate(moveDirection * _moveSpeed * Time.deltaTime);
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

            // 대쉬 방향과 속도를 결정하여 이동
            float dashSpeed = Vector2.Distance(playerPosition, mousePosition) / _dashDuration;

            //대쉬시 바라보는 방향 수정
            

            // 대쉬 속도가 너무 클 경우 최대 속도로 제한
            dashSpeed = Mathf.Clamp(dashSpeed, 0f, _dashPower);

            Vector2 dashVelocity = dashDirection * dashSpeed;
            rigid.velocity = dashVelocity;

            

            // 일정 시간 후에 속도 0, 허나 기술 사용 시 위 함수가 배제됨
            StartCoroutine(StopDashing());
        }
    }


    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashDuration);
        rigid.velocity = new Vector2(0f, 0f);
    }
    #endregion

    #region 바라보는 방향
    public bool isFacingRight
    {
        get { return _isFacingRight; }
        private set
        {
            _isFacingRight = value;
        }
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
            Debug.LogError("방향 꺾음 : 우측");
            transform.localScale *= new Vector2(-1, 1);
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            isFacingRight = false;
            Debug.LogError("방향 꺾음 : 좌측");
            transform.localScale *= new Vector2(1, 1);
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
