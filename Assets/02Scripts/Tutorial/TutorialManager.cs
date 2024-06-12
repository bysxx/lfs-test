using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public List<TutorialBase> tutorials;
    private TutorialBase curTutorial;
    public int curIdx = -1;

    private void Update() {
        if (curTutorial != null)
            curTutorial.Activate(this);
    }

    public void SetNextTutorial() {

        if (curTutorial != null) curTutorial.Exit(this);

        if (curIdx >= tutorials.Count - 1) {
            CompletedAllTutorials();
            return;
        }

        curIdx++;
        curTutorial = tutorials[curIdx];

        curTutorial.Enter(this);
    }

    public void CompletedAllTutorials() {
        curTutorial = null;
        Define.Log("Complete All");
        
    }
}
