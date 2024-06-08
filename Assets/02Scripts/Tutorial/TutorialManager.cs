using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public List<TutorialBase> tutorials;
    private TutorialBase curTutorial;
    private int curIdx = -1;

    private void Update() {
        if (curTutorial != null)
            curTutorial.Activate(this);
    }

    public void SetNextTutorial() {

        if (curTutorial != null) curTutorial.Exit();

        if (curIdx >= tutorials.Count - 1) {
            CompletedAllTutorials();
            return;
        }

        curIdx++;
        curTutorial = tutorials[curIdx];

        curTutorial.Enter();
    }

    public void CompletedAllTutorials() {
        curTutorial = null;
        Access.GameM.isTutorialCleared = true;
        Define.Log("Complete All");
        
    }
}
