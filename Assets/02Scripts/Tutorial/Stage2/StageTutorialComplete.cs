using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTutorialComplete : TutorialBase
{
    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph endTalk;
    [SerializeField] private string nextScene;
    [SerializeField] private int curStage;

    private bool isTalkEnd;

    protected override bool IsCompleted => isTalkEnd;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter() {
        endTalk.BindEventAtEventNode("EndTalkEndEvent", EndTalkEndEvent);
        Access.DIalogueM.RegisterDialogue(endTalk);
    }

    public override void Exit() {
        endTalk.RemoveEventAtEventNode("EndTalkEndEvent", EndTalkEndEvent);
        Access.GameM.stageProgress[curStage] = true;
        Access.UIM.FadeToScene(nextScene);
    }

    private void EndTalkEndEvent() {
        isTalkEnd = true;
    }
}
