using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float damage = 10f; // 히트박스가 줄 데미지
    [SerializeField] private float knockbackPower = 5f; // 넉백 위력

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // 적에게 데미지를 주고 넉백을 적용하는 로직
            var enemy = collision.GetComponent<Distant>();
            if (enemy != null)
            {
                enemy.UpdateState(EState.Hitted);
            }
        }
    }

    //TODO : 매개변수 int 들을 받아 하나는 데미지, 하나는 넉백 위력(높을 수록 강넉백, 0이면 없음, 1이면 경직 수준), 하나는 WIP
}
