using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainChickenController : Singleton<MainChickenController>
{
  public Text DebugText;
  
  public float InteractionProximity = 2f;
  public GameObject GrumpyChicken;
  public GameObject NeighborChicken;

  private bool _inGrumpyChickenProximity;
  private bool _isGrumpyChickenVisible;

  private bool _inNeighborChickenProximity;
  private bool _isNeighborChickenVisible;

  public GameObject LeftHandGrabber;
  public GameObject RightHandGrabber;

  public bool IsHoldingItem;
  public List<GameObject> HeldItems = new List<GameObject>();

  private void Update()
  {
    _inGrumpyChickenProximity = (Vector3.Distance(transform.position, GrumpyChicken.transform.position) <= InteractionProximity) ? true : false;
    _isGrumpyChickenVisible = GrumpyChicken.GetComponent<Renderer>().isVisible;

    _isNeighborChickenVisible = (Vector3.Distance(transform.position, NeighborChicken.transform.position) <= InteractionProximity) ? true : false;
    _isNeighborChickenVisible = NeighborChicken.GetComponent<Renderer>().isVisible;

// DISTANCE CHECKING
    if (Vector3.Distance(transform.position, GrumpyChicken.transform.position) <= InteractionProximity && !GrumpyChicken.GetComponent<NPCChicken>().IsSpeaking)// && LoveChicken.GetComponent<Renderer>().isVisible)
    {
      GrumpyChicken.GetComponent<NPCChicken>().TalkButton.SetActive(true);
    }
    else
    {
      GrumpyChicken.GetComponent<NPCChicken>().TalkButton.SetActive(false);
    }

    if (Vector3.Distance(transform.position, NeighborChicken.transform.position) <= InteractionProximity && !NeighborChicken.GetComponent<NPCChicken>().IsSpeaking)// && NeighborChicken.GetComponent<Renderer>().isVisible)
    {
      NeighborChicken.GetComponent<NPCChicken>().TalkButton.SetActive(true);
    }
    else
    {
      NeighborChicken.GetComponent<NPCChicken>().TalkButton.SetActive(false);
    }

// ITEM CHECKING
    if(LeftHandGrabber.GetComponent<OVRGrabber>().GrabbedObject == null && RightHandGrabber.GetComponent<OVRGrabber>().GrabbedObject == null) IsHoldingItem = false;
    else if (LeftHandGrabber.GetComponent<OVRGrabber>().GrabbedObject != null || RightHandGrabber.GetComponent<OVRGrabber>().GrabbedObject != null) IsHoldingItem = true;

    if (IsHoldingItem)
    {
      if (LeftHandGrabber.GetComponent<OVRGrabber>().GrabbedObject != null) HeldItems.Add(LeftHandGrabber.GetComponent<OVRGrabber>().GrabbedObject.gameObject);
      if (RightHandGrabber.GetComponent<OVRGrabber>().GrabbedObject != null) HeldItems.Add(RightHandGrabber.GetComponent<OVRGrabber>().GrabbedObject.gameObject);
    }
    else
    {
      HeldItems.Clear();
    }

    DebugText.text = string.Format("Holding Item? {0} \nHeld Items: {1}, {2}", IsHoldingItem, HeldItems[0], HeldItems[1]);
  }
}
