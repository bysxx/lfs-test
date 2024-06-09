using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotTutorial : TutorialBase {

    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph gunShotTalk;
    [SerializeField] private Quest gunShotQuest;

    private Quest newQuest;

    protected override bool IsCompleted => newQuest != null && newQuest.IsComplete;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter() {
        gunShotTalk.BindEventAtEventNode("GunShotEvent", GunShotEvent);
        Access.DIalogueM.RegisterDialogue(gunShotTalk);
        Access.Player.P_DInfo.CurGunWeapon.CanShot = false;
    }

    public override void Exit() {
        gunShotTalk.RemoveEventAtEventNode("GunShotEvent", GunShotEvent);
    }

    private void GunShotEvent() {
        newQuest = Access.QuestM.Register(gunShotQuest);
        Access.Player.P_DInfo.CurGunWeapon.CanShot = true;
    }
}
