using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulletGetTutorial : TutorialBase
{
    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph specialBulletGetTutorialTalk;
    [SerializeField] private Quest specialBulletGetTutorialQuest;
    [SerializeField] private List<Answer> tutorialBulletList;

    private Quest newQuest;

    protected override bool IsCompleted => newQuest != null && newQuest.IsComplete;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter() {
        specialBulletGetTutorialTalk.BindEventAtEventNode("BulletSpawnEvent", BulletSpawnEvent);
        specialBulletGetTutorialTalk.BindEventAtEventNode("PlayerMoveEvent", PlayerMoveEvent);
        Access.DIalogueM.RegisterDialogue(specialBulletGetTutorialTalk);
        Access.Player.StopPlayer();
    }

    public override void Exit() {
        specialBulletGetTutorialTalk.RemoveEventAtEventNode("BulletSpawnEvent", BulletSpawnEvent);
        specialBulletGetTutorialTalk.RemoveEventAtEventNode("PlayerMoveEvent", PlayerMoveEvent);
    }

    private void BulletSpawnEvent() {
        Access.BossStageM.SpawnSpecialBullet(tutorialBulletList);
    }

    private void PlayerMoveEvent() {
        Access.Player.MovePlayer();
        newQuest = Access.QuestM.Register(specialBulletGetTutorialQuest);
    }
}
