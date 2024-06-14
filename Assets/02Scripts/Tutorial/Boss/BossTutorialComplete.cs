using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTutorialComplete : TutorialBase
{
    [SerializeField] private Quest mainQuest;
    [SerializeField] DialogueGraph endDialogue;

    protected override bool IsCompleted => dialogueCompleted;
    private bool dialogueCompleted;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            Access.GameM.isTutorialCleared = true;
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter(TutorialManager tutorialManager) {
        endDialogue.BindEventAtEventNode("BossGameStartEvent", BossGameStartEvent);
        Access.DIalogueM.RegisterDialogue(endDialogue);
    }

    public override void Exit(TutorialManager tutorialManager) {
        endDialogue.RemoveEventAtEventNode("BossGameStartEvent", BossGameStartEvent);
    }

    private void BossGameStartEvent() {
        dialogueCompleted = true;
        StartCoroutine(TutorialEnd_CO());
    }

    private IEnumerator TutorialEnd_CO() {
        yield return StartCoroutine(Access.BossStageM.BossStageStart_CO());
        Access.QuestM.Register(mainQuest);

    }

}
