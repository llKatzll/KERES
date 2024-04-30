using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : MonoBehaviour, DistantState
{
    [SerializeField] private Transform _playerLocation;
    public void EnterState()
    {
        Debug.Log("����Ʈ DeadStart");
    }
    public void ExitState()
    {
        Debug.Log("����Ʈ DeadEND");
    }
    public void UpdateState()
    {
        Debug.Log("����Ʈ Dead, ���� �پ�ٴҰž����� �پ�ٴҰž����� �پ�ٴҰž����� �پ�ٴҰž����� �پ�ٴҰž�");
        transform.position = _playerLocation.position;
    }

}
