using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

  // * DialogueGroups (each group corresponds to the current objective);
  //   * DialogueGroup
  //     * dialogue
  //     * dialogue
  //     * dialogue
  //     * dialogue
  //     * dialogue
  //     * dialogue
  //     * dialogue
  //   * DialogueGroup
  //     * dialogue
  //     * dialogue
  //     * dialogue
  //   * DialogueGroup
  //     * dialogue
  //     * dialogue
  //     * dialogue
  //   * DialogueGroup
  //     * dialogue
  //     * dialogue
  //     * dialogue

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

  public int CurrentDialogueGroup => TaskChecker.Instance.CurrentTaskIndex;
  public int CurrentDialogue;
  
  private void Start()
  {
    CurrentDialogue = 0;

    TalkButton.SetActive(true);
    TextBox.SetActive(false);
  }

  public void Speak()
  {
    TaskChecker.Instance.EvaluateCurrentTask();
    
    IsSpeaking = true;

    TextBox.SetActive(true);
    TalkButton.SetActive(false);

    TextArea.text = " ";

    if (CurrentDialogue != DialogueGroups[CurrentDialogueGroup].Dialogues.Count && !MainChickenController.Instance.HoldingItem)  // Checks if the CurrentDialogue isn't the last one in the list
    {
      TextArea.text = DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].DialogueString;
      CurrentDialogue++;
    }
    else if (CurrentDialogue != DialogueGroups[CurrentDialogueGroup].Dialogues.Count && MainChickenController.Instance.HoldingItem)
    {
      TextArea.text = "why are you holding a " + MainChickenController.Instance.HeldItems[0].name + "?";
      CurrentDialogue = DialogueGroups[CurrentDialogueGroup].Dialogues.Count;
    }
    else
    {
      TextBox.SetActive(false);
      TalkButton.SetActive(true);
      CurrentDialogue = 0;
      IsSpeaking = false;
    }
  }

  public void WithItemsResponse()
  {
    TextArea.text = "why are you holding a " + MainChickenController.Instance.HeldItems[0].name + "?";
  }

  public void NoItemsResponse()
  {
    TextBox.SetActive(true);
    TalkButton.SetActive(false);

    TextArea.text = " ";

    if (CurrentDialogue != DialogueGroups[CurrentDialogueGroup].Dialogues.Count)  // Checks if the CurrentDialogue isn't the last one in the list
    {
      // if (!DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].NeedsResponse)
      // {
      //   TextArea.text = DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].DialogueString;
      //   CurrentDialogue++;
      // }
      // else
      // {
      //   // * Set response button 1 and 2
      //   //   * Set text on button
      //   //   * Upon clicking a button:
      //   //     * Set the next dialogue index (ie: currentdialogue = x)
      //   //     * Call the Speak() method
      //   // * Show response buttons
      // }

      TextArea.text = DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].DialogueString;
      CurrentDialogue++;
    }
    else
    {
      TextBox.SetActive(false);
      TalkButton.SetActive(true);
      CurrentDialogue = 0;
      IsSpeaking = false;
    }
  }
}