using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : MonoBehaviour, DistantState
{
    private Distant _distant;

    public void EnterState()
    {
        Debug.Log("����Ʈ DeadStart");
        Debug.Log("����..! ����Ʈ��! â���� ���� ����!! ����Ʈ��!!!");
        StartCoroutine(Ambatublow());
    }
    public void ExitState()
    {
        //nothing
    }
    public void UpdateState()
    {
        //nothing
    }

    IEnumerator Ambatublow()
    {
        //TESTCODE
        yield return new WaitForSeconds(2f);
        Debug.Log("���� �� ����");
        Destroy(this.gameObject);
    }

}
