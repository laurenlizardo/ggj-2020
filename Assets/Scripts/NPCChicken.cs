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
  
  [System.Serializable]
  public class Dialogue
  {
    public string DialogueText;
    public int NextDialogueIndex;
  }

  [System.Serializable]
  public class DialogueGroup
  {
    public List<Dialogue> Dialogues = new List<Dialogue>();
  }

  public List<DialogueGroup> DialogueGroups = new List<DialogueGroup>();



}