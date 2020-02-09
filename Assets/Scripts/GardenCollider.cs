using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenCollider : MonoBehaviour
{
  private void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.name == "HoseNozzle") TaskChecker.Instance.GardenWatered = true;
  }
}
