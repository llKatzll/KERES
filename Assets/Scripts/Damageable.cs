using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [Header("Damage, KnockBack")]
    [SerializeField] private float damage = 10f; // 히트박스가 줄 데미지
    [SerializeField] private float knockbackPower = 100f; // 넉백 위력

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Distant>();
            if (enemy != null)
            {
                enemy.health -= damage; // 체력 감소
                ApplyKnockback(transform.position, knockbackPower, enemy.GetComponent<Rigidbody2D>());
                enemy.UpdateState(EState.Hitted);
            }
        }
    }

    public void ApplyKnockback(Vector2 hitPosition, float knockbackPower, Rigidbody2D enemyRigidbody)
    {
        if (enemyRigidbody != null)
        {
            Vector2 knockbackDirection = (enemyRigidbody.transform.position - (Vector3)hitPosition).normalized;
            Debug.Log($"Applying knockback: Direction = {knockbackDirection}, Power = {knockbackPower}");
            enemyRigidbody.velocity = Vector2.zero; // 이전 속도를 초기화하여 누적되지 않도록 합니다.
            enemyRigidbody.AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("No Rigidbody2D found on the enemy object.");
        }
    }
}
