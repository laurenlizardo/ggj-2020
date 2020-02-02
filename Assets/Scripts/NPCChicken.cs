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
  public GameObject TextBox;
  public GameObject InteractBox;
  
  [System.Serializable]
  public class Dialogue
  {
    public string DialogueID;
    [TextArea]
    public string DialogueString;
    public bool NeedsResponse;
  }

  [System.Serializable]
  public class DialogueGroup
  {
    public string GroupID;
    public List<Dialogue> Dialogues = new List<Dialogue>();
  }

  public List<DialogueGroup> DialogueGroups = new List<DialogueGroup>();

  public int CurrentDialogueGroup;
  public int CurrentDialogue;
  
  private void Start()
  {
    CurrentDialogueGroup = 0;
    CurrentDialogue = 0;

    InteractBox.SetActive(true);
    TextBox.SetActive(false);
  }

  // public void Speak()
  // {
  //   bool LastDialogue = (CurrentDialogue == DialogueGroups[CurrentDialogueGroup].Dialogues.Count);
  //   bool NeedsResponse = DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].NeedsResponse;

  //   InteractBox.SetActive(false);
  //   TextBox.SetActive(true);

  //   if (LastDialogue)
  //   {
  //     InteractBox.SetActive(true);
  //     TextBox.SetActive(false);
  //     CurrentDialogue = 0;
  //   }
  //   else if (CurrentDialogue != DialogueGroups[CurrentDialogueGroup].Dialogues.Count)  // Checks if the CurrentDialogue isn't the last one in the list
  //   {
  //     if (!NeedsResponse) //(!DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].NeedsResponse)
  //     {
  //       TextArea.text = DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].DialogueString;
  //       CurrentDialogue++;
  //     }
  //     else
  //     {
  //       // * Set response button 1 and 2
  //       //   * Set text on button
  //       //   * Upon clicking a button:
  //       //     * Set the next dialogue index (ie: currentdialogue = x)
  //       //     * Call the Speak() method
  //       // * Show response buttons
  //     }
  //   }
  // }


  public void ManuallySetNextDialogue(int index)
  {
    CurrentDialogue = index;
  }

  public void ManuallySetNextDialogueGroup(int index)
  {
    CurrentDialogueGroup = index;
  }

  public void Speak()
  {
    if (TextBox.activeSelf == false)
    {
      TextBox.SetActive(true);
      InteractBox.SetActive(false);
    }

    TextArea.text = " ";

    if (CurrentDialogue != DialogueGroups[CurrentDialogueGroup].Dialogues.Count)  // Checks if the CurrentDialogue isn't the last one in the list
    {
      
      if (!DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].NeedsResponse)
      {
        TextArea.text = DialogueGroups[CurrentDialogueGroup].Dialogues[CurrentDialogue].DialogueString;
        CurrentDialogue++;
      }
      else
      {
        // * Set response button 1 and 2
        //   * Set text on button
        //   * Upon clicking a button:
        //     * Set the next dialogue index (ie: currentdialogue = x)
        //     * Call the Speak() method
        // * Show response buttons
      }
    }
    else
    {
      TextBox.SetActive(false);
      InteractBox.SetActive(true);
      CurrentDialogue = 0;
    }
  }
}