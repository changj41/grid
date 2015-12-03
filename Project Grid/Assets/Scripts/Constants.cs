using UnityEngine;
using System.Collections;

public static class Constants {

  public static class Board
  {
    public const float boardZ = 8;
    public const float boardX = 4;
  }

  public static class Path
  {
    public const string GreenTilePrefab = "Prefabs/Green";
    public const string BlueTilePrefab = "Prefabs/Blue";
    public const string WhiteTilePrefab = "Prefabs/White";
  }

  public static class Tags
  {
    public const string MainCamera = "MainCamera";
    public const string MovementRangeIndicator = "MovementRangeIndicator";
    public const string BoardTile = "BoardTile";
  }
}
