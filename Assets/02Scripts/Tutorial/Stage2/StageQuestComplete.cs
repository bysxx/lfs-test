using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageQuestComplete : TutorialBase {

    [Header("Tutorial Info")]
    [SerializeField] private Quest tvQuest;
    [SerializeField] private DialogueGraph nextTalk;

    protected override bool IsCompleted => Access.QuestM.CompletedQuests.Find(x => x.ID == tvQuest.ID) != null;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter() {
        
    }

    public override void Exit() {
        if (nextTalk != null)
            Access.DIalogueM.RegisterDialogue(nextTalk);
    }

}
