﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceRailCollider : MonoBehaviour
{
  public Transform FenceRailTransform;
  public Transform FenceRailTransformBroken;

  private void Start()
  {
    transform.localPosition = FenceRailTransform.localPosition;
    transform.localRotation = FenceRailTransform.localRotation;
    GetComponent<Rigidbody>().isKinematic = true;
  }

  private void Update()
  {
    if (TaskChecker.Instance.CurrentTaskIndex == 4)
    {
      if (!TaskChecker.Instance.FenceFixed)
      {
        GetComponent<Rigidbody>().isKinematic = false;
        transform.localPosition = FenceRailTransformBroken.localPosition;
        transform.localRotation = FenceRailTransformBroken.localRotation;
      }
    }

    if (TaskChecker.Instance.FenceFixed)
    {
      transform.localPosition = FenceRailTransform.localPosition;
      transform.localRotation = FenceRailTransform.localRotation;
      GetComponent<Rigidbody>().isKinematic = true;
    }
  }

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.name == "Hammer") TaskChecker.Instance.FenceFixed = true;
  }
}
