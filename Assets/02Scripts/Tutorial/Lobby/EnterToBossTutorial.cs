using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToBossTutorial : TutorialBase
{
    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph enterLobbyTalk;
    [SerializeField] private DialogueGraph lunaThirdMeetTalk;
    [SerializeField] private Quest goToStage3Quest;
    [SerializeField] private GameObject stage3Teleport;
    [SerializeField] private GameObject lunaObj;
    [SerializeField] private GameObject saniObj;
    [SerializeField] private GameObject bagiObj;

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

        lunaThirdMeetTalk.BindEventAtEventNode("LunaThirdMeetTalkEnterEvent", LunaThirdMeetTalkEnterEvent);
        lunaThirdMeetTalk.BindEventAtEventNode("LunaThirdMeetTalkExitEvent", LunaThirdMeetTalkExitEvent);
        enterLobbyTalk.BindEventAtEventNode("EnterLobbyEvent", EnterLobbyEvent);
        Access.DIalogueM.RegisterDialogue(enterLobbyTalk);
        Access.Player.StopOnlyMove();
    }

    public override void Exit(TutorialManager tutorialManager) {
        enterLobbyTalk.RemoveEventAtEventNode("EnterLobbyEvent", EnterLobbyEvent);
        lunaThirdMeetTalk.RemoveEventAtEventNode("LunaThirdMeetTalkEnterEvent", LunaThirdMeetTalkEnterEvent);
        lunaThirdMeetTalk.RemoveEventAtEventNode("LunaThirdMeetTalkExitEvent", LunaThirdMeetTalkExitEvent);
    }

    private void EnterLobbyEvent() {
        Access.Player.MovePlayer();
        lunaObj.SetActive(true);
        saniObj.SetActive(true);
        bagiObj.SetActive(true);
    }

    private void LunaThirdMeetTalkEnterEvent() {
        Access.Player.StopOnlyMove();
    }

    private void LunaThirdMeetTalkExitEvent() {
        newQuest = Access.QuestM.Register(goToStage3Quest);
        Access.Player.MovePlayer();
        stage3Teleport.SetActive(true);
    }
}
