using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator _anim;


    [SerializeField] private bool _isAttacking = false; // 현재 공격 중인지 여부
    private bool _isIdle = true; // 대기 상태 여부
    private float _lastAttackTime; // 마지막 공격 시간

    //[SerializeField] private BoxCollider2D[] _hitboxes;

    [Header("Time")]
    [SerializeField] private float _waitTime = 0.3f; // 공격 대기 시간

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
