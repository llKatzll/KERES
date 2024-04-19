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
    //skill ��뿩��
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
            // ���� DirectionCheck ������Ʈ�� ���ٸ� ������ ����մϴ�.
            Debug.LogError("DirectionCheck ������Ʈ�� ã�� �� �����ϴ�.");
        }

        _originalGravityScale = rigid.gravityScale;


    }

    #region ������
    public void Moving()
    {
        float x = Input.GetAxisRaw("Horizontal");

        // x ���� 0�� �ƴϸ� �̵�
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


    #region ����
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

    #region �뽬
    private bool isDash = false;
    public void Dashing()
    {
        GameObject _mouseLocater = GameObject.Find("MousePositionHelper");

        if(Input.GetKeyDown(KeyCode.LeftShift) && isDash)
        {
            Debug.Log("�뽬 ��ٿ�. ���� �ܿ��ð� : " + _dashCoolDown);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDash)
        {
            isDash = true;
            Debug.Log(_mouseLocater.transform.position);

            Vector2 mouseLocaterPos = new Vector2(_mouseLocater.transform.position.x, _mouseLocater.transform.position.y);

            Vector2 playerPosition = transform.position;

            Vector2 dashDirection = (mouseLocaterPos - playerPosition).normalized;

            Debug.Log("Now Dashing");

            // �뽬 ����� �ӵ��� �����Ͽ� �̵�
            float dashSpeed = Vector2.Distance(playerPosition, mouseLocaterPos) / _dashDuration;

            anim.SetTrigger(AnimationStrings.Dash);

            //�뽬�� �ٶ󺸴� ���� ����
            if (dashDirection.x > 0f)
            {
                _isFacingLeft = false;
            }
            else
            {
                _isFacingLeft = true;
            }

            // �뽬 �ӵ��� �ʹ� Ŭ ��� �ִ� �ӵ��� ����
            dashSpeed = Mathf.Clamp(dashSpeed, 0f, _dashPower);

            Vector2 dashVelocity = dashDirection * dashSpeed;
            rigid.velocity = dashVelocity;

            // ���� �ð� �Ŀ� �ӵ� 0, �㳪 ��� ��� �� �� �Լ��� ������
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

    #region �ٶ󺸴� ����
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

    #region ���������� ���� ��ȯ
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

    #region �߷� �ʱ�ȭ
    IEnumerator ResetGravity()
    {
        yield return new WaitForSeconds(_dashDuration);
        rigid.gravityScale = _originalGravityScale;
    }
    #endregion
}
