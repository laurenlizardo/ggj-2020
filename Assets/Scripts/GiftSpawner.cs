using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
  private static GiftSpawner _instance;
  public static GiftSpawner Instance => _instance;

  private void Awake()
  {
    _instance = this;
  }

  public GameObject Gift;
  public Transform Spawnpoint;
  public bool GiftSpawned;

  private void Start()
  {
    Gift.SetActive(false);
  }

  public void SpawnGift()
  {
    Gift.transform.position = Spawnpoint.position;
    Gift.SetActive(true);
    GiftSpawned = true;
  }
}
