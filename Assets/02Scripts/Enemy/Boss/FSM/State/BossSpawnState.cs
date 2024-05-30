using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnState : State {

    public delegate void OnBossKilledAllEnemyHandler();
    public static event OnBossKilledAllEnemyHandler OnBossKilledAllEnemy;

    private BossController bossController;

    [Header("Spawn Info")]
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject spawnEffect;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private int[] spawnCnt;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float patternTimer;

    private float curSpawnTime;
    private int curLevel = -1;
    private PopUpUI timerUI;

    public override void Activate() {
        if (bossController != null) {

            Access.BossStageM.PatternTimer.Accessor -= Time.deltaTime;
            if (Access.BossStageM.PatternTimer.Accessor <= 0) {
                Access.BossStageM.PatternTimer.Accessor = 0;
                KillAllEnemy();
                bossController.Fsm.Transition(bossController.IdleState);
                if (!TutorialManager.isTutorialCleared) GetComponent<QuestReporter>().Report(0);
            }

            curSpawnTime += Time.deltaTime;
            if (curSpawnTime >= spawnTimer) {
                StartCoroutine(SpawnEnemySeveralTimes(spawnCnt[curLevel]));
                curSpawnTime = 0;
            }

        }
    }

    public override void Enter(Controller controller) {
        curLevel++;
        if (curLevel >= spawnCnt.Length) curLevel = spawnCnt.Length - 1;
        curSpawnTime = spawnTimer;
        Access.BossStageM.PatternTimer.Accessor = patternTimer;
        bossController = controller as BossController;
        timerUI = Access.UIM.ShowPopupUI<PopUpUI>("TimerPanel");
    }

    public override void Exit() {
        bossController = null;
        Access.UIM.ClosePopupUI(timerUI);
        timerUI = null;
    }

    private IEnumerator SpawnEnemy(int cnt) {

        Transform[] result = GetRandomTransforms(cnt, spawnPos.transform);

        foreach (Transform t in result) {
            Instantiate(spawnEffect, t.position, Quaternion.identity);
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], t.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator SpawnEnemySeveralTimes(int cnt) {
        for (int i = 0; i < cnt; i++) {
            StartCoroutine(SpawnEnemy(Random.Range(3, 7)));
            yield return new WaitForSeconds(1f);
        }
    }

    private Transform[] GetRandomTransforms(int cnt, Transform origin) {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in origin) {
            children.Add(child);
        }

        if (children.Count <= cnt) {
            return children.ToArray();
        }

        System.Random random = new();
        int n = children.Count;

        for (int i = n - 1; i > 0; i--) {
            int j = random.Next(0, i + 1);
            Transform temp = children[i];
            children[i] = children[j];
            children[j] = temp;
        }

        return children.GetRange(0, cnt).ToArray();
    }

    public void KillAllEnemy() {
        OnBossKilledAllEnemy?.Invoke();
    }
}
