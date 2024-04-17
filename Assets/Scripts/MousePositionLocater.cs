using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionLocater : MonoBehaviour
{
    [SerializeField] private Vector3 mousePosition;

    [SerializeField] private Transform _player;

    [SerializeField] private GameObject _arrow;

    [SerializeField] private float _rotationSpeed;

    void FixedUpdate()
    {
        Vector3 newPosition = GetWorldPositionOnPlane(Input.mousePosition, 100);
        newPosition.z = 0;
        transform.position = newPosition;

        Vector3 direction = _player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle + 90f,Vector3.forward);
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
