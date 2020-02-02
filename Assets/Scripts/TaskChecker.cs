using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskChecker : MonoBehaviour
{
  private static TaskChecker _instance;
  public static TaskChecker Instance => _instance;

  private void Awake()
  {
    _instance = this;
  }

  public int CurrentTaskIndex = 0;
  public bool CoffeeGiven;
  public bool GardenWatered;
  public bool ChickenFed;
  public bool FenceFixed;
  public bool GiftDelivered;

  public void EvaluateCurrentTask()
  {
    if (CurrentTaskIndex == 0 && CoffeeGiven)
    {
      IncrementTaskIndex();
    }
    else if (CurrentTaskIndex == 1 && GardenWatered)
    {
      IncrementTaskIndex();
    }
    else if (CurrentTaskIndex == 2 && ChickenFed)
    {
      IncrementTaskIndex();
    }
    else if (CurrentTaskIndex == 3 && FenceFixed)
    {
      IncrementTaskIndex();
    }
    else if (CurrentTaskIndex == 4 && GiftDelivered)
    {
      IncrementTaskIndex();
    }
  }

  private void IncrementTaskIndex()
  {
    if (CurrentTaskIndex < 6) CurrentTaskIndex++;
  }

  private void Update()
  {
    if (OVRInput.GetUp(OVRInput.Button.One))
    {
      if (!CoffeeGiven) CoffeeGiven = true;
      else if (CoffeeGiven && !GardenWatered) GardenWatered = true;
      else if (CoffeeGiven && GardenWatered && !ChickenFed) ChickenFed = true;
      else if (CoffeeGiven && GardenWatered && ChickenFed && !FenceFixed) FenceFixed = true;
      else if (CoffeeGiven && GardenWatered && ChickenFed && FenceFixed && !GiftDelivered) GiftDelivered = true;
    }
  }

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.name == "Coffee") CoffeeGiven = true;
    if (collider.gameObject.name == "Food") ChickenFed = true;
  }

  private void OnTriggerExit(Collider collider)
  {
    if (collider.gameObject.name == "Coffee") CoffeeGiven = false;
    if (collider.gameObject.name == "Food") ChickenFed = false;
  }
}
