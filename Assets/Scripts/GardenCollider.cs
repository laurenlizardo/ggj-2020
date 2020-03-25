using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenCollider : MonoBehaviour
{
  private void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.name == "HoseNozzle") TaskManager.Instance.GardenWatered = true;
  }
}
