using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
  public OVRPlayerController PlayerController;
  public GameObject TutorialUI;

  public void StartGame()
  {
    PlayerController.EnableLinearMovement = true;
    TutorialUI.SetActive(false);
  }

  private void Start()
  {
    PlayerController.EnableLinearMovement = false;
    TutorialUI.SetActive(true);
    GameSettings.Instance.CurrentGameState = GameSettings.GameState.GAME;
  }
}
