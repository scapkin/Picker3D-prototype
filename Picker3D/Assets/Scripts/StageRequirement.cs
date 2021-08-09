using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using RemoteNotification = UnityEngine.iOS.RemoteNotification;

public class StageRequirement : MonoBehaviour
{
    public int requirement;
    public int collected;
    public GameObject picker;
    public GameObject follow;

    public LeanDragTranslateRigidbody leanTouch;

    private bool isEntered;


    private void Start()
    {
        picker = GameObject.Find("Picker");
        follow = GameObject.Find("CameraFollow");
        leanTouch = picker.GetComponent<LeanDragTranslateRigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collectable"))
        {
            collected++;
            Destroy(other.gameObject);
            StartCoroutine(StageControl());
        }
    }

    private IEnumerator StageControl()
    {
        yield return new WaitForSeconds(2f);
        if (collected >= requirement)
        {
            StartCoroutine(GroundUp());
        }
        else
        {
            UiManager.Instance.LevelFailUi();
        }
    }


    private IEnumerator GroundUp()
    {

        transform.parent.position = new Vector3(transform.parent.position.x, Mathf.Lerp(-0.9f, 0.045f, 0.5f), transform.parent.position.z);
        yield return new WaitForSeconds(1f);
        picker.GetComponent<Movement>().isForce = true;
        follow.GetComponent<Movement>().isForce = true;
        leanTouch.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Picker.Instance.isStoped = false;
    }
}