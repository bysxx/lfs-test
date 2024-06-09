
using UnityEngine;

public class GameManager : DontDestroySingleton<GameManager> {

    public bool isTutorialCleared;
    public bool[] stageProgress = new bool[3];
}