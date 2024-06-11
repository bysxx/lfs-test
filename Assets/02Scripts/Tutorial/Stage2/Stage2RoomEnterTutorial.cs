using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2RoomEnterTutorial : TutorialBase {

    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph stage2EnterTalk;

    private bool isTalkEnd;

    protected override bool IsCompleted => isTalkEnd;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter() {
        stage2EnterTalk.BindEventAtEventNode("Stage2EnterEvent", Stage2EnterEvent);
        Access.DIalogueM.RegisterDialogue(stage2EnterTalk);
        Access.Player.StopPlayer();
    }

    public override void Exit() {
        stage2EnterTalk.RemoveEventAtEventNode("Stage2EnterEvent", Stage2EnterEvent);
    }

    private void Stage2EnterEvent() {
        isTalkEnd = true;
        Access.Player.MovePlayer();
    }
}
