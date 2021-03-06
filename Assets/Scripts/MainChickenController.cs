﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainChickenController : MonoBehaviour
{
  private static MainChickenController _instance;
  public static MainChickenController Instance => _instance;

  private void Awake()
  {
    _instance = this;
  }

  public Text DebugText;
  
  public float InteractionProximity = 2f;
  public GameObject LoveChicken;
  public GameObject NeighborChicken;

  private bool _inLoveChickenProximity;
  private bool _LoveChickenVisible;

  private bool _inNeighborChickenProximity;
  private bool _NeighborChickenVisible;

  public GameObject LeftGrabber;
  public GameObject RightGrabber;

  public bool HoldingItem;
  public List<GameObject> HeldItems = new List<GameObject>();

  private void Update()
  {
    _inLoveChickenProximity = (Vector3.Distance(transform.position, LoveChicken.transform.position) <= InteractionProximity) ? true : false;
    _LoveChickenVisible = LoveChicken.GetComponent<Renderer>().isVisible;

    _NeighborChickenVisible = (Vector3.Distance(transform.position, NeighborChicken.transform.position) <= InteractionProximity) ? true : false;
    _NeighborChickenVisible = NeighborChicken.GetComponent<Renderer>().isVisible;

// DISTANCE CHECKING
    if (Vector3.Distance(transform.position, LoveChicken.transform.position) <= InteractionProximity && !LoveChicken.GetComponent<NPCChicken>().IsSpeaking)// && LoveChicken.GetComponent<Renderer>().isVisible)
    {
      LoveChicken.GetComponent<NPCChicken>().TalkButton.SetActive(true);
    }
    else
    {
      LoveChicken.GetComponent<NPCChicken>().TalkButton.SetActive(false);
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
    if(LeftGrabber.GetComponent<OVRGrabber>().GrabbedObject == null && RightGrabber.GetComponent<OVRGrabber>().GrabbedObject == null) HoldingItem = false;
    else if (LeftGrabber.GetComponent<OVRGrabber>().GrabbedObject != null || RightGrabber.GetComponent<OVRGrabber>().GrabbedObject != null) HoldingItem = true;

    if (HoldingItem)
    {
      if (LeftGrabber.GetComponent<OVRGrabber>().GrabbedObject != null) HeldItems.Add(LeftGrabber.GetComponent<OVRGrabber>().GrabbedObject.gameObject);
      if (RightGrabber.GetComponent<OVRGrabber>().GrabbedObject != null) HeldItems.Add(RightGrabber.GetComponent<OVRGrabber>().GrabbedObject.gameObject);
    }
    else
    {
      HeldItems.Clear();
    }

    DebugText.text = string.Format("Holding Item? {0} \nHeld Items: {1}, {2}", HoldingItem, HeldItems[0], HeldItems[1]);
  }
}
