using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGetTutorial : TutorialBase {

    [Header("Gun Info")]
    [SerializeField] private GameObject gunSpawnEffect;
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunSpawnPos;

    [Header("Tutorial Info")]
    [SerializeField] private DialogueGraph gunGetTutorialDialogue;
    [SerializeField] private Quest gunGetQuest;

    private Quest newQuest;

    protected override bool IsCompleted => newQuest != null && newQuest.IsComplete;

    public override void Activate(TutorialManager tutorialManager) {
        if (IsCompleted) {
            Define.Log("¿Ï·á");
            tutorialManager.SetNextTutorial();
        }
    }

    public override void Enter() {
        Access.Player.StopPlayer();
        gunGetTutorialDialogue.BindEventAtEventNode("GunSpawnEvent", GunSpawn);
        Access.DIalogueM.RegisterDialogue(gunGetTutorialDialogue);
    }

    public override void Exit() {
        gunGetTutorialDialogue.RemoveEventAtEventNode("GunSpawnEvent", GunSpawn);
    }

    private void GunSpawn() {
        Instantiate(gunSpawnEffect, gunSpawnPos.position, Quaternion.identity);
        Instantiate(gunPrefab, gunSpawnPos.position, Quaternion.identity);
        newQuest = Access.QuestM.Register(gunGetQuest);
        Access.Player.MovePlayer();
    }
}
