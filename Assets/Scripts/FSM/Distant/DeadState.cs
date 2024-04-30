using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : MonoBehaviour, DistantState
{
    private Distant _distant;

    public void EnterState()
    {
        Debug.Log("디스턴트 DeadStart");
        Debug.Log("나는..! 디스턴트다! 창백한 고래를 잡을!! 디스턴트다!!!");
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
        Debug.Log("터질 것 같애");
        Destroy(this.gameObject);
    }

}
