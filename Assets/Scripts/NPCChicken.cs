using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCChicken : MonoBehaviour
{
  public string Name;
  public Text TextArea;
  public GameObject TalkButton;
  public GameObject TextBox;
  public GameObject NextButton;
  public bool IsSpeaking;
  
  [System.Serializable]
  public class Dialogue
  {
    [TextArea]
    public string DialogueString;
  }

  [System.Serializable]
  public class DialogueGroup
  {
    public List<Dialogue> Dialogues = new List<Dialogue>();
  }

  public List<DialogueGroup> DialogueGroups = new List<DialogueGroup>();

  public int CurrentDialogueGroup => TaskManager.Instance.CurrentTaskIndex;
  public int CurrentDialogue;
  
  private void Start()
  {
    CurrentDialogue = 0;

    TalkButton.SetActive(true);
    TextBox.SetActive(false);
  }

  public void Speak()
  {
    TaskManager.Instance.EvaluateCurrentTask();

    IsSpeaking = true;

    TextBox.SetActive(true);
    TalkButton.SetActive(false);

    TextArea.text = " ";

    if (CurrentDialogue != DialogueGroups[CurrentDialogueGroup].Dialogues.Count && !MainChickenController.Instance.IsHoldingItem)  // Checks if the CurrentDialogue isn't the last one in the list
    {
      TextArea.text = DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].DialogueString;
      CurrentDialogue++;
      if (CurrentDialogueGroup == 3 && CurrentDialogue == 3 && TaskManager.Instance.FenceFixed == false)
      {
        TaskManager.Instance.Fence1.GetComponent<FenceRailCollider>().BreakFence();
        TaskManager.Instance.Fence2.GetComponent<FenceRailCollider>().BreakFence();
      }
      if (CurrentDialogueGroup == 4 && CurrentDialogue == DialogueGroups[CurrentDialogueGroup].Dialogues.Count && GiftSpawner.Instance.GiftSpawned == false)
      {
        GiftSpawner.Instance.SpawnGift();
      }
    }
    else if (CurrentDialogue != DialogueGroups[CurrentDialogueGroup].Dialogues.Count && MainChickenController.Instance.IsHoldingItem)
    {
      TextArea.text = "Put that down before you speak to me.";
      CurrentDialogue = DialogueGroups[CurrentDialogueGroup].Dialogues.Count;
    }
    else
    {
      if (CurrentDialogueGroup == 5 && CurrentDialogue == DialogueGroups[CurrentDialogueGroup].Dialogues.Count)
      {
        GameSettings.Instance.CurrentGameState = GameSettings.GameState.END;
      }

      TextBox.SetActive(false);
      TalkButton.SetActive(true);
      CurrentDialogue = 0;
      IsSpeaking = false;
    }
  }
}