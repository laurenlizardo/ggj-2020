using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceRailCollider : MonoBehaviour
{
  public Transform FenceRailTransform;

  private void Update()
  {
    if (TaskChecker.Instance.FenceFixed)
    {
      transform.localPosition = FenceRailTransform.localPosition;
      transform.localRotation = FenceRailTransform.localRotation;
    }
  }

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.name == "Hammer") TaskChecker.Instance.FenceFixed = true;
  }
}
