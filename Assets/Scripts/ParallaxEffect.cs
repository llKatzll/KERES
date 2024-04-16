using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    [SerializeField] private Transform _followTarget;

    //���� ��ġ
    Vector2 _startingPosition;

    //ī�޶� ���� ��ġ�κ��� ��ŭ �̵��ߴ����� ���� ���͸� ���Ѵ�.
    Vector2 _camMoveSinceStart => (Vector2)_cam.transform.position - _startingPosition;
    //���� Z�� ��ġ���� ���󰡴� Ÿ���� Z�� ��ġ ����(�Ÿ����̸� ���Ѵ�.)
    float _zDistanceFromTarget => transform.position.z - _followTarget.transform.position.z;

    float clippingPlane => (_cam.transform.position.z + _zDistanceFromTarget) > 0 ? _cam.farClipPlane : _cam.nearClipPlane;

    float parallaxFactor => Mathf.Abs(_zDistanceFromTarget) / clippingPlane;

    [SerializeField] private float _parallaxEffectSpeed;

    //���ٽ�
    // �����̸� = �� �ϸ� �����̸��� ���̶�°ǵ�, 
    // ���ٽ����� => �ع����� ���� �����̸��� ������ �� �ִ�. ��°Ŵ�..


    public float ParallaxFactor()
    {
        return Mathf.Abs(_zDistanceFromTarget) / clippingPlane;
    }

    //���� Z�� ��
    float _startingZ;

    //public float StartingZ
    //{
    //    get { return StartingZ; }
    //    set { StartingZ = value; }
    //}

    private void Start()
    {
        _startingPosition = transform.position;
        _startingZ = transform.localPosition.z;
    }

    private void Update()
    {


        Vector2 _newPosition = _startingPosition + _camMoveSinceStart / parallaxFactor;

        transform.position = new Vector3(_newPosition.x * _parallaxEffectSpeed, _newPosition.y * _parallaxEffectSpeed, _startingZ);
        //������ �����ϱ� �̷� �ڵ尡 �ִپ�
        //Mathf.Abs = ���밪�̾��� ����
    }

    //void Update()
    //{
    //    //Ÿ���� ���������� ���� �ڽ��� �������� ����
    //    transform.position = -(_followTarget.transform.position);
    //}
}
