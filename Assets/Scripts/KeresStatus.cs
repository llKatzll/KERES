using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeresStatus : MonoBehaviour
{
    public int _knifeStack = 3;

    private int KnifeStack
    {
        get { return _knifeStack; }
        set { _knifeStack = value; }
    }

    private void Awake()
    {
        _knifeStack = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
