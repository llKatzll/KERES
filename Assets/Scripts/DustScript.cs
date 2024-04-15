using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject dustPrefab; // Dust ������Ʈ�� ������

    bool dustSpawned = false;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // ���� ��ġ�� 3.5 �̻��̸� ���ο� Dust ������Ʈ�� �����Ͽ� �Ʒ��� ����
        if (transform.position.y >= 3.5f && !dustSpawned)
        {
            Vector3 spawnPoint = new Vector3(0, -8f, 0);
            //dustPrefab.transform.position = new Vector3(2.5f, 2.5f, 0);
            GameObject newDust = Instantiate(dustPrefab, spawnPoint, Quaternion.identity);


            if (Random.Range(0, 2) == 1)
            {
                Vector3 scale = newDust.transform.localScale;
                scale.x *= -1f;
                newDust.transform.localScale = scale;
            }
            newDust.name = "Dust";
            dustSpawned = true;
        }

        // ���� ��ġ�� 6 �̻��̸� ���� ������Ʈ ����
        if (transform.position.y >= 6f)
        {
            Destroy(gameObject);
        }
    }
}