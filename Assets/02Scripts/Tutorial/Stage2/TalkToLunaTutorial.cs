using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToLunaTutorial : TutorialBase
{
    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph lunaTalk;

    private bool isTalkEnd;

    protected override bool IsCompleted => isTalkEnd;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("�Ϸ�");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter() {
        lunaTalk.BindEventAtEventNode("LunaTalkEndEvent", LunaTalkEndEvent);
        lunaTalk.BindEventAtEventNode("LunaTalkStartEvent", LunaTalkStartEvent);

    }

    public override void Exit() {
        lunaTalk.RemoveEventAtEventNode("LunaTalkEndEvent", LunaTalkEndEvent);
        lunaTalk.RemoveEventAtEventNode("LunaTalkStartEvent", LunaTalkStartEvent);
    }

    private void LunaTalkEndEvent() {
        isTalkEnd = true;
        Access.Player.MovePlayer();
    }

    private void LunaTalkStartEvent() {
        isTalkEnd = false;
        Access.Player.StopOnlyMove();
    }
}
