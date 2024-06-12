using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEndinTutorial : TutorialBase
{
    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph enterLobbyTalk;
    private bool isDialogueEnded;

    protected override bool IsCompleted => isDialogueEnded;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            Access.GameM.lobbyTutorials[tutorialManager.curIdx] = true;
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter(TutorialManager tutorialManager) {
        if (Access.GameM.lobbyTutorials[tutorialManager.curIdx]) {
            tutorialManager.SetNextTutorial();
            return;
        }

        enterLobbyTalk.BindEventAtEventNode("EnterLobbyEvent", EnterLobbyEvent);
        Access.DIalogueM.RegisterDialogue(enterLobbyTalk);
        Access.Player.StopOnlyMove();
    }

    public override void Exit(TutorialManager tutorialManager) {
        enterLobbyTalk.RemoveEventAtEventNode("EnterLobbyEvent", EnterLobbyEvent);
    }

    private void EnterLobbyEvent() {
        isDialogueEnded = true;
        Access.UIM.FadeToScene("MainMenu");
    }

}
