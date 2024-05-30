using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public List<TutorialBase> tutorials;
    private TutorialBase curTutorial;
    private int curIdx = -1;

    public static bool isTutorialCleared;

    private void Update() {
        if (curTutorial != null)
            curTutorial.Activate(this);
    }

    public void SetNextTutorial() {

        if (curTutorial != null) curTutorial.Exit();

        if (curIdx >= tutorials.Count - 1) {
            CompletedAllTutorials();
            isTutorialCleared = true;
            return;
        }

        curIdx++;
        curTutorial = tutorials[curIdx];

        curTutorial.Enter();
    }

    public void CompletedAllTutorials() {
        curTutorial = null;

        Define.Log("Complete All");
        
    }
}
