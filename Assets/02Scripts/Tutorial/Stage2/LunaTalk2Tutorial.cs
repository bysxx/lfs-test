using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaTalk2Tutorial : TutorialBase
{
    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph lunaTalk;
    [SerializeField] private GameObject phone;

    private bool isTalkEnd;

    protected override bool IsCompleted => isTalkEnd;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter(TutorialManager tutorialManager) {
        lunaTalk.BindEventAtEventNode("LunaTalkEndEvent", LunaTalkEndEvent);
        lunaTalk.BindEventAtEventNode("LunaTalkStartEvent", LunaTalkStartEvent);
        lunaTalk.BindEventAtEventNode("PlayerMoveEvent", PlayerMoveEvent);

    }

    public override void Exit(TutorialManager tutorialManager) {
        lunaTalk.RemoveEventAtEventNode("LunaTalkEndEvent", LunaTalkEndEvent);
        lunaTalk.RemoveEventAtEventNode("LunaTalkStartEvent", LunaTalkStartEvent);
        lunaTalk.BindEventAtEventNode("PlayerMoveEvent", PlayerMoveEvent);
    }

    private void LunaTalkEndEvent() {
        isTalkEnd = true;
    }

    private void LunaTalkStartEvent() {
        isTalkEnd = false;
        Access.Player.StopOnlyMove();
    }

    private void PlayerMoveEvent() {
        Access.Player.MovePlayer();
        phone.SetActive(true);
        Access.UIM.ShowPopupUI<PopUpUI>("PhonePanel");
    }
}
