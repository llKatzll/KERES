using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTCODE : MonoBehaviour
{
    Rigidbody2D rigid;

    float velocity = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = 5 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.L))
        {
            velocity = 10 * Time.deltaTime;
        }
        Debug.Log(velocity);
    }
}
