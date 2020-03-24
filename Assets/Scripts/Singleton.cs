using UnityEngine;

/// <summary>
/// A generic implementation of the singleton design pattern for Unity development.
/// </summary>
public abstract class Singleton<T> : MonoBehaviour where T : Component
{
  private static T _instance;
  public static T Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = FindObjectOfType<T>();
        if (_instance == null) _instance = new GameObject().AddComponent<T>();
      }

      _instance.name = string.Format("{0} (Singleton)", typeof(T).ToString());
      DontDestroyOnLoad(_instance);

      return _instance;
    }
  }
}