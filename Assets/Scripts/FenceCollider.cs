using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceCollider : MonoBehaviour
{
  private void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.name == "Hammer") TaskChecker.Instance.FenceFixed = true;
  }
}
