using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulletShotTutorial : TutorialBase {

    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph specialBulletShotTutorialTalk;
    [SerializeField] private Quest specialBulletShotTutorialQuest;

    private Quest newQuest;

    protected override bool IsCompleted => newQuest != null && newQuest.IsComplete;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            Access.BossStageM.DestroyAllBullet();
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter() {
        specialBulletShotTutorialTalk.BindEventAtEventNode("SpecialBulletShotEvent", SpecialBulletShotEvent);
        Access.Player.P_DInfo.CurGunWeapon.CanShot = false;
        Access.DIalogueM.RegisterDialogue(specialBulletShotTutorialTalk);
    }

    public override void Exit() {
        specialBulletShotTutorialTalk.RemoveEventAtEventNode("SpecialBulletShotEvent", SpecialBulletShotEvent);
    }

    private void SpecialBulletShotEvent() {
        newQuest = Access.QuestM.Register(specialBulletShotTutorialQuest);
        Access.Player.P_DInfo.CurGunWeapon.CanShot = true;
    }
}
