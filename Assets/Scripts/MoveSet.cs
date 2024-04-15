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
            playerPosition = Vector2.Lerp(playerPosition, dashDirection, _dashDuration);

            anim.SetTrigger(AnimationStrings.Dash);

            StartCoroutine(ResetGravity());
        }
    }
    #endregion

    #region �ٶ󺸴� ����
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
