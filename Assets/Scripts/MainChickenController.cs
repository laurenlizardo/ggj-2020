using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChickenController : MonoBehaviour
{
  public float InteractionProximity = 2f;
  public GameObject LoveChicken;
  public GameObject NeighborChicken;

  private bool _inLoveChickenProximity;
  private bool _LoveChickenVisible;

  private bool _inNeighborChickenProximity;
  private bool _NeighborChickenVisible;

  private void Update()
  {
    _inLoveChickenProximity = (Vector3.Distance(transform.position, LoveChicken.transform.position) <= InteractionProximity) ? true : false;
    _LoveChickenVisible = LoveChicken.GetComponent<Renderer>().isVisible;

    _NeighborChickenVisible = (Vector3.Distance(transform.position, NeighborChicken.transform.position) <= InteractionProximity) ? true : false;
    _NeighborChickenVisible = NeighborChicken.GetComponent<Renderer>().isVisible;

    if (OVRInput.GetUp(OVRInput.Button.One) || OVRInput.GetUp(OVRInput.Button.Three))
    {
      if (Vector3.Distance(transform.position, LoveChicken.transform.position) <= InteractionProximity && LoveChicken.GetComponent<Renderer>().isVisible)
      {
        LoveChicken.GetComponent<NPCChicken>().Speak();
      }

      if (Vector3.Distance(transform.position, NeighborChicken.transform.position) <= InteractionProximity && NeighborChicken.GetComponent<Renderer>().isVisible)
      {
        NeighborChicken.GetComponent<NPCChicken>().Speak();
      }
    }
  }
}
