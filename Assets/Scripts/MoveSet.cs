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
    public void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(mousePosition);

            Vector2 playerPosition = transform.position;

            Vector2 dashDirection = (mousePosition - playerPosition).normalized;

            Debug.Log("Now Dashing");

            // �뽬 ����� �ӵ��� �����Ͽ� �̵�
            float dashSpeed = Vector2.Distance(playerPosition, mousePosition) / _dashDuration;

            //�뽬�� �ٶ󺸴� ���� ����
            

            // �뽬 �ӵ��� �ʹ� Ŭ ��� �ִ� �ӵ��� ����
            dashSpeed = Mathf.Clamp(dashSpeed, 0f, _dashPower);

            Vector2 dashVelocity = dashDirection * dashSpeed;
            rigid.velocity = dashVelocity;

            

            // ���� �ð� �Ŀ� �ӵ� 0, �㳪 ��� ��� �� �� �Լ��� ������
            StartCoroutine(StopDashing());
        }
    }


    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashDuration);
        rigid.velocity = new Vector2(0f, 0f);
    }
    #endregion

    #region �ٶ󺸴� ����
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
            Debug.LogError("���� ���� : ����");
            transform.localScale *= new Vector2(-1, 1);
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            isFacingRight = false;
            Debug.LogError("���� ���� : ����");
            transform.localScale *= new Vector2(1, 1);
        }
    }
    #endregion

    #region Ŀ�ǵ� �Է� ����
    public void OnCommandInput(Ecommands ecommands)
    {
        Debug.Log(message: "Ŀ�ǵ� �Է� ����" + ecommands);
        Debug.Log(message: "���⼭ Switch�� ����ؼ� ���ϴ� �ִϸ��̼� ���");

        switch (ecommands)
        {
            case Ecommands.ASDQ:
                //�������������Ӷ��󤿤�����������ȣ��ȣȣȫ��
                Debug.Log("ASDQ!");
                break;
            case Ecommands.WADQ:
                //�̾Ʒ��Ʒ����������� ��� ������ �׷��� ���� ���������嵐
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

    #region �߷� �ʱ�ȭ
    IEnumerator ResetGravity()
    {
        yield return new WaitForSeconds(_dashDuration);
        rigid.gravityScale = _originalGravityScale;
    }
    #endregion
}
