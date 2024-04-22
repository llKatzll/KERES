using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostDelay;
    private float ghostDelayTime;
    public SpriteRenderer playerSpriteRenderer; // ���� �÷��̾��� SpriteRenderer
    public int orderOffset = 1; // �ܻ��� order in layer�� ������ ��
    public bool makeGhost;

    void Start()
    {
        this.ghostDelayTime = this.ghostDelay;
    }

    void FixedUpdate()
    {
        if (this.makeGhost)
        {
            if (this.ghostDelayTime > 0)
            {
                this.ghostDelayTime -= Time.deltaTime;
            }
            else
            {
                // ���ο� �ܻ� ����
                GameObject ghostObject = new GameObject("Ghost");
                SpriteRenderer ghostRenderer = ghostObject.AddComponent<SpriteRenderer>();
                ghostRenderer.sprite = playerSpriteRenderer.sprite; // �÷��̾��� ��������Ʈ ����
                ghostRenderer.color = new Color(1f, 1f, 1f, 0.6f); // ���� ����

                // �ܻ��� ��ġ ����
                ghostObject.transform.position = transform.position - new Vector3(0f, 0.1f, 0f); // �÷��̾� ��ġ���� �ణ ���� �̵�
                ghostObject.transform.rotation = transform.rotation; // �÷��̾��� ȸ���� ����
                ghostObject.transform.localScale = transform.localScale; // �÷��̾��� ũ��� ����

                // �÷��̾��� "order in layer" ���� offset�� ���Ͽ� �ܻ��� ������ ����
                ghostRenderer.sortingOrder = playerSpriteRenderer.sortingOrder + orderOffset;
                ghostRenderer.sortingLayerName = "Ghost";

                Destroy(ghostObject, 0.8f); // �ܻ� ����

                this.ghostDelayTime = this.ghostDelay;
                
            }
        }
    }
}
