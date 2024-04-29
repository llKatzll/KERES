using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class KeresStatus : MonoBehaviour
{
    [SerializeField] private EachKnifeStack[] _knives;

    public int _knifeStack = 0;

    public int KnifeStack
    {
        get { return _knifeStack; }
        set { _knifeStack = value; }
    }

    public void IncreaseStack(int amount)
    {
        if (_knifeStack == 3)
            return;


        int cnt = 0;

        // 범위기반 for문 범위 기반<< ? 
        foreach (var k in _knives)
        {
            if(!k.StackON)
            {
                k.StackON = true;
                cnt++;
                _knifeStack++;

                if (cnt == amount)
                    return;
            }
        }
    }

    public void DecreaseStack(int amount)
    {
        if (_knifeStack == 0)
            return;

        int cnt = 0;
        Debug.Log(amount);

        for(int i = _knives.Length; i > 0; --i)
        {
            var k = _knives[i - 1];

            if (k.StackON)
            {
                k.StackON = false;
                cnt++;
                _knifeStack--;

                if (cnt == amount)
                    return;
            }
        }
    }
}
