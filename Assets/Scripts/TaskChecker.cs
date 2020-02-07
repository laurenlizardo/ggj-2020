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

  public GameObject Fence1;
  public GameObject Fence2;

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
    else if (CurrentTaskIndex == 5 && GameSettings.Instance.CurrentGameState == GameSettings.GameState.END)
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

    if (FenceFixed)
    {
      Fence1.transform.localPosition = new Vector3(.2f, .55f, 0);
      Fence1.transform.localRotation = Quaternion.Euler(0, 360, 0);
      Fence2.transform.localPosition = new Vector3(.2f, .9f, 0);
      Fence2.transform.localRotation = Quaternion.Euler(0, 360, 0);
    }
  }

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.name == "Coffee") CoffeeGiven = true;
    if (collider.gameObject.tag == "Food") ChickenFed = true;
    if (collider.gameObject.name == "Gift") GiftDelivered = true;
  }

  private void OnTriggerExit(Collider collider)
  {
    if (collider.gameObject.name == "Coffee") CoffeeGiven = false;
    if (collider.gameObject.tag == "Food") ChickenFed = false;
    if (collider.gameObject.name == "Gift") GiftDelivered = false;
  }
}
