using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator _anim;


    [SerializeField] private bool _isAttacking = false; // ���� ���� ������ ����
    private bool _isIdle = true; // ��� ���� ����
    private float _lastAttackTime; // ������ ���� �ð�

    //[SerializeField] private BoxCollider2D[] _hitboxes;

    [Header("Time")]
    [SerializeField] private float _waitTime = 0.3f; // ���� ��� �ð�

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger(AnimationStrings.Attack);
        }
    }

    

}
