using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChickenController : MonoBehaviour
{
  public float InteractionProximity = 2f;
  public GameObject LoveChicken;
  public GameObject NeighborChicken;

  private bool _inProximity;
  private bool _LoveChickenVisible;

  private void Update()
  {
    _inProximity = (Vector3.Distance(transform.position, LoveChicken.transform.position) <= InteractionProximity) ? true : false;
    _LoveChickenVisible = LoveChicken.GetComponent<Renderer>().isVisible;

    if ( _inProximity && _LoveChickenVisible)
    {
      // Show dialogue
      Debug.Log("LoveChicken is in view");

      if (OVRInput.GetUp(OVRInput.Button.One) || OVRInput.GetUp(OVRInput.Button.Three))
      {
        LoveChicken.GetComponent<NPCChicken>().TextArea.text += LoveChicken.GetComponent<NPCChicken>().Name;
      }
    }


  }
}
