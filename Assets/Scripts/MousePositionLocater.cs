using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MousePositionLocater : MonoBehaviour
{
    [SerializeField] private Vector3 mousePosition;

    [SerializeField] private Transform _player;

    [SerializeField] private GameObject _arrow;

    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float maxDistance = 5f; // �ִ� �Ÿ��� ���ϴ� ������ ����
    [SerializeField] private float minDistance = 2f; // �ּ� �Ÿ��� ���ϴ� ������ ����

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = true;
    }

    void FixedUpdate()
    {
        Vector3 newPosition = GetWorldPositionOnPlane(Input.mousePosition, 100);
        newPosition.z = 0;

        Vector3 direction = newPosition - _player.position;
        float distance = direction.magnitude;

        // �Ÿ��� �ּ� �Ÿ����� ������ �ּ� �Ÿ��� �̵�
        if (distance < minDistance)
        {
            newPosition = _player.position + direction.normalized * minDistance;
        }
        // �Ÿ��� �ִ� �Ÿ����� ũ�� �ִ� �Ÿ��� �̵�
        else if (distance > maxDistance)
        {
            newPosition = _player.position + direction.normalized * maxDistance;
        }

        transform.position = newPosition;

        


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle - 90f,Vector3.forward);
        _arrow.transform.rotation = Quaternion.Slerp(_arrow.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
