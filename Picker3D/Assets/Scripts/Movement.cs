using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rg;
    public bool isForce;

    public float speed;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isForce)
        {
            rg.velocity = Vector3.forward * (speed * Time.deltaTime);
        }
        
    }
    
}
