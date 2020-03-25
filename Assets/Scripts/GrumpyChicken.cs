using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrumpyChicken : NPCChicken
{
private void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.name == "Coffee") TaskManager.Instance.CoffeeGiven = true;
    if (collider.gameObject.tag == "Food") TaskManager.Instance.ChickenFed = true;
    if (collider.gameObject.name == "Gift") TaskManager.Instance.GiftDelivered = true;
  }
}
