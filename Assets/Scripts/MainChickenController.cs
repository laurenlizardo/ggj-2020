using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChickenController : MonoBehaviour
{
  public float InteractionRadius = 2f;
  public GameObject LoveChicken;
  public GameObject NeighborChicken;

  private void Update()
  {
    if ( (Vector3.Distance(transform.position, LoveChicken.transform.position) <= InteractionRadius) && LoveChicken.GetComponent<Renderer>().isVisible)
    {
      // Show dialogue
      Debug.Log("LoveChicken is in view");
    }
  }
}
