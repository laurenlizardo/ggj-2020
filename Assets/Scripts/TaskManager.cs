using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{

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
    // For testing purposes only
    if (OVRInput.GetUp(OVRInput.Button.One))
    {
      if (!CoffeeGiven) CoffeeGiven = true;
      else if (CoffeeGiven && !GardenWatered) GardenWatered = true;
      else if (CoffeeGiven && GardenWatered && !ChickenFed) ChickenFed = true;
      else if (CoffeeGiven && GardenWatered && ChickenFed && !FenceFixed) FenceFixed = true;
      else if (CoffeeGiven && GardenWatered && ChickenFed && FenceFixed && !GiftDelivered) GiftDelivered = true;
    }
  }

  
}
