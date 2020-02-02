﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
  private static GameSettings _instance;
  public static GameSettings Instance => _instance;

  private void Awake()
  {
    _instance = this;
  }

  public enum GameState
  {
    INTRO, GAME, END
  }

  public GameState CurrentGameState;
}