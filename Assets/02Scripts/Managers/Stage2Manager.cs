using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Manager : NormalSingleton<Stage2Manager>
{
    [SerializeField] private TutorialManager tutorialManager;

    private IEnumerator Start() {

        yield return null;

        tutorialManager.SetNextTutorial();
    }
}
