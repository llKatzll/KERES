using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostDelay;
    private float ghostDelayTime;
    public SpriteRenderer playerSpriteRenderer; // 원래 플레이어의 SpriteRenderer
    public int orderOffset = 1; // 잔상의 order in layer를 조정할 값
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
                // 새로운 잔상 생성
                GameObject ghostObject = new GameObject("Ghost");
                SpriteRenderer ghostRenderer = ghostObject.AddComponent<SpriteRenderer>();
                ghostRenderer.sprite = playerSpriteRenderer.sprite; // 플레이어의 스프라이트 설정
                ghostRenderer.color = new Color(1f, 1f, 1f, 0.6f); // 투명도 설정

                // 잔상의 위치 설정
                ghostObject.transform.position = transform.position - new Vector3(0f, 0.1f, 0f); // 플레이어 위치에서 약간 위로 이동
                ghostObject.transform.rotation = transform.rotation; // 플레이어의 회전과 동일
                ghostObject.transform.localScale = transform.localScale; // 플레이어의 크기와 동일

                // 플레이어의 "order in layer" 값에 offset을 더하여 잔상의 순서를 조정
                ghostRenderer.sortingOrder = playerSpriteRenderer.sortingOrder + orderOffset;
                ghostRenderer.sortingLayerName = "Ghost";

                Destroy(ghostObject, 0.8f); // 잔상 삭제

                this.ghostDelayTime = this.ghostDelay;
                
            }
        }
    }
}
