using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToElecTutorial : TutorialBase
{
    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph enterLobbyTalk;
    [SerializeField] private DialogueGraph lunaSecondMeetTalk;
    [SerializeField] private Quest goToStage2Quest;
    [SerializeField] private GameObject stage2Teleport;
    [SerializeField] private GameObject lunaObj;
    [SerializeField] private GameObject saniObj;

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

        lunaSecondMeetTalk.BindEventAtEventNode("LunaSecondMeetTalkEnterEvent", LunaSecondMeetTalkEnterEvent);
        lunaSecondMeetTalk.BindEventAtEventNode("LunaSecondMeetTalkExitEvent", LunaSecondMeetTalkExitEvent);
        enterLobbyTalk.BindEventAtEventNode("EnterLobbyEvent", EnterLobbyEvent);
        Access.DIalogueM.RegisterDialogue(enterLobbyTalk);
        Access.Player.StopOnlyMove();
    }

    public override void Exit(TutorialManager tutorialManager) {
        enterLobbyTalk.RemoveEventAtEventNode("EnterLobbyEvent", EnterLobbyEvent);
        lunaSecondMeetTalk.RemoveEventAtEventNode("LunaSecondMeetTalkEnterEvent", LunaSecondMeetTalkEnterEvent);
        lunaSecondMeetTalk.RemoveEventAtEventNode("LunaSecondMeetTalkExitEvent", LunaSecondMeetTalkExitEvent);
    }

    private void EnterLobbyEvent() {
        Access.Player.MovePlayer();
        lunaObj.SetActive(true);
        saniObj.SetActive(true);
    }

    private void LunaSecondMeetTalkEnterEvent() {
        Access.Player.StopOnlyMove();
    }

    private void LunaSecondMeetTalkExitEvent() {
        newQuest = Access.QuestM.Register(goToStage2Quest);
        Access.Player.MovePlayer();
        stage2Teleport.SetActive(true);
    }
}
