using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLobbyTutorial : TutorialBase {

    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph enterLobbyTalk;
    [SerializeField] private DialogueGraph lunaFirstMeetTalk;
    [SerializeField] private Quest goToStage1Quest;
    [SerializeField] private GameObject stage1Teleport;
    [SerializeField] private GameObject lunaObj;

    private Quest newQuest;

    protected override bool IsCompleted => newQuest != null && newQuest.IsComplete;

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

        lunaFirstMeetTalk.BindEventAtEventNode("LunaFirstMeetTalkEnterEvent", LunaFirstMeetTalkEnterEvent);
        lunaFirstMeetTalk.BindEventAtEventNode("LunaFirstMeetTalkExitEvent", LunaFirstMeetTalkExitEvent);
        enterLobbyTalk.BindEventAtEventNode("EnterLobbyEvent", EnterLobbyEvent);
        Access.DIalogueM.RegisterDialogue(enterLobbyTalk);
        Access.Player.StopOnlyMove();
    }

    public override void Exit(TutorialManager tutorialManager) {
        enterLobbyTalk.RemoveEventAtEventNode("EnterLobbyEvent", EnterLobbyEvent);
        lunaFirstMeetTalk.RemoveEventAtEventNode("LunaFirstMeetTalkEnterEvent", LunaFirstMeetTalkEnterEvent);
        lunaFirstMeetTalk.RemoveEventAtEventNode("LunaFirstMeetTalkExitEvent", LunaFirstMeetTalkExitEvent);
    }

    private void EnterLobbyEvent() {
        Access.Player.MovePlayer();
    }

    private void LunaFirstMeetTalkEnterEvent() {
        lunaObj.SetActive(true);
    }

    private void LunaFirstMeetTalkExitEvent() {
        newQuest = Access.QuestM.Register(goToStage1Quest);
        Access.Player.MovePlayer();
        stage1Teleport.SetActive(true);
        lunaObj.SetActive(false);
    }

}
