using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnTutorial : TutorialBase {

    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph bossPattern1Talk;
    [SerializeField] private Quest bossPattern1Quest;
    [SerializeField] private float maxSpawnTime;

    private BossController bossController;

    private Quest newQuest;

    protected override bool IsCompleted => newQuest != null && newQuest.IsComplete;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter(TutorialManager tutorialManager) {
        bossPattern1Talk.BindEventAtEventNode("BossPattern1Event", BossPattern1Event);
        Access.DIalogueM.RegisterDialogue(bossPattern1Talk);
    }

    public override void Exit(TutorialManager tutorialManager) {
        bossPattern1Talk.RemoveEventAtEventNode("BossPattern1Event", BossPattern1Event);
    }

    private void BossPattern1Event() {
        StartCoroutine(BossPattern1Event_CO());
    }

    private IEnumerator BossPattern1Event_CO() {
        newQuest = Access.QuestM.Register(bossPattern1Quest);
        bossController = Access.BossStageM.SpawnBoss();

        yield return new WaitForSeconds(1.5f);

        bossController.SetPattern(0);
    }
}
