using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern2Tutorial : TutorialBase {

    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph bossPattern2TutorialTalk;
    [SerializeField] private Quest bossPattern2TutorialQuest;

    private Quest newQuest;
    private BossController bossController;

    protected override bool IsCompleted => newQuest != null && newQuest.IsComplete;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter() {
        bossPattern2TutorialTalk.BindEventAtEventNode("BossPattern2Event", BossPattern2Event);
        Access.DIalogueM.RegisterDialogue(bossPattern2TutorialTalk);
    }

    public override void Exit() {
        bossPattern2TutorialTalk.RemoveEventAtEventNode("BossPattern2Event", BossPattern2Event);
    }

    private void BossPattern2Event() {
        newQuest = Access.QuestM.Register(bossPattern2TutorialQuest);
        bossController = Access.BossStageM.bossController;
        bossController.SetPattern(1);
    }
}
