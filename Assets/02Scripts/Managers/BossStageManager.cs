using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageManager : MonoBehaviour
{

    [Header("Boss Info")]
    [SerializeField] private BossController bossPrefab;
    [SerializeField] private Vector3 spawnPos;

    [Header("NPC Info")]
    [SerializeField] private DialogueProvider npcDialogueProvider;
    [SerializeField] private DialogueGraph gunTutorialInfo;

    [SerializeField] private BossController boss;

    private IEnumerator Start() {

        gunTutorialInfo.BindEventAtEventNode("BossSpawnEvent", SpawnBoss);

        yield return new WaitForSeconds(2f);
        npcDialogueProvider.Provide(gunTutorialInfo);
    }

    private void SpawnBoss() {
        boss = Instantiate(bossPrefab, spawnPos, Quaternion.identity);
    }

}
