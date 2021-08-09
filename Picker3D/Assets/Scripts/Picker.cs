using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class Picker : Singleton<Picker>
{
    public Transform stage0;
    public Transform stage1;
    public Transform stage2;
    public Rigidbody follow;

    private Rigidbody rg;

    public bool isStoped;

    private void Start()
    {
        follow = GameObject.Find("CameraFollow").GetComponent<Rigidbody>();
        rg = GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (!isStoped)
        {
            Debug.Log("VAR");
            if (transform.position.z < stage0.position.z && transform.position.z > stage0.position.z - 1f)
            {
                GetComponent<Movement>().isForce = false;
                follow.GetComponent<Movement>().isForce = false;
                follow.velocity = Vector3.zero;
                rg.velocity = Vector3.zero;
                gameObject.GetComponent<LeanDragTranslateRigidbody>().enabled = false;
                isStoped = true;
            }

            if (transform.position.z < stage1.position.z && transform.position.z > stage1.position.z - 1f)
            {
                GetComponent<Movement>().isForce = false;
                follow.GetComponent<Movement>().isForce = false;
                follow.velocity = Vector3.zero;
                rg.velocity = Vector3.zero;
                gameObject.GetComponent<LeanDragTranslateRigidbody>().enabled = false;
                isStoped = true;
            }

            if (transform.position.z < stage2.position.z && transform.position.z > stage2.position.z - 1f)
            {
                GetComponent<Movement>().isForce = false;
                follow.GetComponent<Movement>().isForce = false;
                follow.velocity = Vector3.zero;
                rg.velocity = Vector3.zero;
                gameObject.GetComponent<LeanDragTranslateRigidbody>().enabled = false;
                isStoped = true;
            }
        }
    }
}