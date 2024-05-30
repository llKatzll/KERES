using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float damage = 10f; // ��Ʈ�ڽ��� �� ������
    [SerializeField] private float knockbackPower = 5f; // �˹� ����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // ������ �������� �ְ� �˹��� �����ϴ� ����
            var enemy = collision.GetComponent<Distant>();
            if (enemy != null)
            {
                enemy.UpdateState(EState.Hitted);
            }
        }
    }

    //TODO : �Ű����� int ���� �޾� �ϳ��� ������, �ϳ��� �˹� ����(���� ���� ���˹�, 0�̸� ����, 1�̸� ���� ����), �ϳ��� WIP
}
