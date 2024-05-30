using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [Header("Damage, KnockBack")]
    [SerializeField] private float damage = 10f; // ��Ʈ�ڽ��� �� ������
    [SerializeField] private float knockbackPower = 100f; // �˹� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Distant>();
            if (enemy != null)
            {
                enemy.health -= damage; // ü�� ����
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
            enemyRigidbody.velocity = Vector2.zero; // ���� �ӵ��� �ʱ�ȭ�Ͽ� �������� �ʵ��� �մϴ�.
            enemyRigidbody.AddForce(knockbackDirection * knockbackPower, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("No Rigidbody2D found on the enemy object.");
        }
    }
}
