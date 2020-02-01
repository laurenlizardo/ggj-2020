
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
  [System.Serializable]
  public class Objective
  {
    [TextArea]
    public string Text;
    public bool IsCompleted;
  }

  public List<Objective> ObjectiveList = new List<Objective>();

  private int _currentObjectiveIndex = 0;
  public Objective CurrentObjective => ObjectiveList[_currentObjectiveIndex];

  private void IncrementObjectiveIndex()
  {
    int oneAbove = _currentObjectiveIndex + 1;
    
    if (oneAbove >= ObjectiveList.Count) _currentObjectiveIndex = 0;
    else _currentObjectiveIndex++;
  }

  private void Start()
  {

  }

  private void Update()
  {
    // Example Functionality
    if (Input.GetKeyUp(KeyCode.Space))
    {
      Debug.Log(string.Format("Objective: {0}, Completed? {1},", CurrentObjective.Text, CurrentObjective.IsCompleted));
    }
    else if (Input.GetKeyUp(KeyCode.UpArrow))
    {
      IncrementObjectiveIndex();
    }
  }
}