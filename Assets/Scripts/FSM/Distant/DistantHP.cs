using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DistantHP : MonoBehaviour
{
    [SerializeField] private float _health;

    [SerializeField] private float _adaptAmount;

    private Distant _distant;

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_health <= 0f)
        {
            _distant.UpdateState(EState.Dead);
        }
    }
}
