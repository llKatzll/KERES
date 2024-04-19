using System.Collections;
using UnityEngine;

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
    [SerializeField] private float _dashBrakeAmountX;
    [SerializeField] private float _dashBrakeAmountY;

    [Header("GroundCheck")]
    [SerializeField] private bool _isGround = true;
    [SerializeField] static float _originalGravityScale;

    [Header("CoolDown About Dash")]
    [SerializeField] private float _dashCoolDown = 2f;

    private Vector2 moveInput;
    private LayerMask groundLayer;

    private DashState currentDashState = DashState.Dash;

    [SerializeField] private bool _isFacingLeft = true;
    //skill 사용여부
    [SerializeField] private bool _isSkillUsing = false;

    public enum DashState
    {
        Dash,
        Dash1,
        Dash2,
    }

    private void Awake()
    {
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
    private bool isDash = false;
    public void Dashing()
    {
        GameObject _mouseLocater = GameObject.Find("MousePositionHelper");

        if(Input.GetKeyDown(KeyCode.LeftShift) && isDash)
        {
            Debug.Log("대쉬 쿨다운. 남은 잔여시간 : " + _dashCoolDown);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDash)
        {
            isDash = true;
            Debug.Log(_mouseLocater.transform.position);

            Vector2 mouseLocaterPos = new Vector2(_mouseLocater.transform.position.x, _mouseLocater.transform.position.y);

            Vector2 playerPosition = transform.position;

            Vector2 dashDirection = (mouseLocaterPos - playerPosition).normalized;

            Debug.Log("Now Dashing");

            // 대쉬 방향과 속도를 결정하여 이동
            float dashSpeed = Vector2.Distance(playerPosition, mouseLocaterPos) / _dashDuration;

            anim.SetTrigger(AnimationStrings.Dash);

            //대쉬시 바라보는 방향 수정
            if (dashDirection.x > 0f)
            {
                _isFacingLeft = false;
            }
            else
            {
                _isFacingLeft = true;
            }

            // 대쉬 속도가 너무 클 경우 최대 속도로 제한
            dashSpeed = Mathf.Clamp(dashSpeed, 0f, _dashPower);

            Vector2 dashVelocity = dashDirection * dashSpeed;
            rigid.velocity = dashVelocity;

            // 일정 시간 후에 속도 0, 허나 기술 사용 시 위 함수가 배제됨
            StartCoroutine(StopDashing());
            StartCoroutine(DashCoolDown());
        }
    }


    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashDuration);
        
        rigid.velocity = new Vector2(rigid.velocity.x / _dashBrakeAmountX, rigid.velocity.y / _dashBrakeAmountY);
        
    }

    private IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(_dashCoolDown);
        isDash = false;
    }
    #endregion

    #region 바라보는 방향
    public bool IsFacingLeft
    {
        get { return _isFacingLeft; }
        set { _isFacingLeft = value; }
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0)
        {
            _isFacingLeft = false;
        }
        else if (moveInput.x < 0)
        {
            _isFacingLeft = true;
        }
    }
    #endregion

    public void SetSkillUsing(bool value)
    {
        _isSkillUsing = value;
    }

    private void FixedUpdate()
    {
        if (!_isSkillUsing)
        {
            Moving();
        }
    }

    private void Update()
    {
        if (!_isSkillUsing)
        {
            Dashing();
            Jumping();
        }
        Flip();
    }

    #region 직접적으로 방향 전환
    private void Flip()
    {
        if (_isFacingLeft)
        {
            transform.localScale = new Vector2(2.5f, 2.5f);
        }
        else
        {
            transform.localScale = new Vector2(-2.5f, 2.5f);
        }
    }
    #endregion

    #region 중력 초기화
    IEnumerator ResetGravity()
    {
        yield return new WaitForSeconds(_dashDuration);
        rigid.gravityScale = _originalGravityScale;
    }
    #endregion
}
