using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionLocater : MonoBehaviour
{
    private Vector3 mousePosition;

    void Update()
    {
        Vector3 newPosition = GetWorldPositionOnPlane(Input.mousePosition, 100);
        newPosition.z = 0;
        transform.position = newPosition;
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
