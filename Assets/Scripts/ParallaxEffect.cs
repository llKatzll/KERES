using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    [SerializeField] private Transform _followTarget;

    //시작 위치
    Vector2 _startingPosition;

    //카메라가 시작 위치로부터 얼만큼 이동했는지에 대한 벡터를 구한다.
    Vector2 _camMoveSinceStart => (Vector2)_cam.transform.position - _startingPosition;
    //현재 Z축 위치에서 따라가는 타겟의 Z축 위치 차이(거리차이를 구한다.)
    float _zDistanceFromTarget => transform.position.z - _followTarget.transform.position.z;

    float clippingPlane => (_cam.transform.position.z + _zDistanceFromTarget) > 0 ? _cam.farClipPlane : _cam.nearClipPlane;

    float parallaxFactor => Mathf.Abs(_zDistanceFromTarget) / clippingPlane;

    [SerializeField] private float _parallaxEffectSpeed;

    //람다식
    // 변수이름 = 값 하면 변수이름이 값이라는건데, 
    // 람다식으로 => 해버리면 값인 변수이름을 가져올 수 있다. 라는거다..


    public float ParallaxFactor()
    {
        return Mathf.Abs(_zDistanceFromTarget) / clippingPlane;
    }

    //시작 Z축 값
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
        //위에꺼 복습하깅 이런 코드가 있다아
        //Mathf.Abs = 절대값이엇넹 ㅋㅋ
    }

    //void Update()
    //{
    //    //타겟이 오른쪽으로 가면 자신은 왼쪽으로 가기
    //    transform.position = -(_followTarget.transform.position);
    //}
}
