using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTutorialComplete : TutorialBase
{

    [SerializeField] DialogueGraph endDialogue;

    protected override bool IsCompleted => dialogueCompleted;
    private bool dialogueCompleted;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
            Access.BossStageM.bossController.Fsm.Transition(Access.BossStageM.bossController.IdleState);
        }
    }

    public override void Enter() {
        endDialogue.BindEventAtEventNode("BossGameStartEvent", BossGameStartEvent);
        Access.DIalogueM.RegisterDialogue(endDialogue);
    }

    public override void Exit() {
        endDialogue.RemoveEventAtEventNode("BossGameStartEvent", BossGameStartEvent);
    }

    private void BossGameStartEvent() {
        dialogueCompleted = true;
    }

}
