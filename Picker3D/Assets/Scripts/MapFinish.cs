using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFinish : MonoBehaviour
{
    private Rigidbody follow;

    private void Start()
    {
        follow = GameObject.Find("CameraFollow").GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out Movement picker))
        {
            UiManager.Instance.LevelFinishController();
            Time.timeScale = 0;
            follow.velocity = Vector3.zero;
            picker.GetComponent<Rigidbody>().velocity =Vector3.zero;
        }
    }
}
