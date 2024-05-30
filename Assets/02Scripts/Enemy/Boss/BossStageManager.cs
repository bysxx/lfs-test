using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageManager : NormalSingleton<BossStageManager>
{
    public delegate void OnDestroyAllBulletHandler();
    public static event OnDestroyAllBulletHandler OnDestroyAllBullet;

    [Header("Game Info")]
    [SerializeField] private Quest mainQuest; 

    [Header("Tutorial")]
    [SerializeField] private TutorialManager tutorialManager;
    public DynamicVariable<float> PatternTimer { get; set; }

    [Header("Boss Info")]
    [SerializeField] private GameObject bossSpawnEffect;
    [SerializeField] private BossController bossPrefab;
    [SerializeField] private Vector3 bossSpawnPos;

    [Header("Special Bullet Info")]
    [SerializeField] private GameObject bulletSpawnEffect;
    [SerializeField] private GameObject specialBulletPrefab;
    [SerializeField] private Transform[] spawnTransforms;

    public BossController bossController { get; private set; }
    public int CurBulletCnt { get; private set; }

    protected override void Awake() {
        base.Awake();
        PatternTimer = new DynamicVariable<float>();
    }

    private void Start() {

        Access.QuestM.Register(mainQuest);

        AnswerBullet.OnDestroyBullet += OnDestroyAnswerBullet;
        tutorialManager.SetNextTutorial();

    }

    private void OnDestroy() {
        AnswerBullet.OnDestroyBullet -= OnDestroyAnswerBullet;
    }

    public BossController SpawnBoss() {
        Instantiate(bossSpawnEffect, bossSpawnPos + new Vector3(0f, 14f, 0f), Quaternion.identity);
        bossController = Instantiate(bossPrefab, bossSpawnPos, Quaternion.identity);
        return bossController;
    }

    public void SpawnSpecialBullet(List<Answer> answerList) {
        StartCoroutine(SpawnSpecialBullet_CO(answerList));
        CurBulletCnt = spawnTransforms.Length;
    }

    private IEnumerator SpawnSpecialBullet_CO(List<Answer> answerList) {
        for (int i = 0; i < spawnTransforms.Length; i++) {
            SpecialBullet b = (Instantiate(specialBulletPrefab, spawnTransforms[i].position, Quaternion.Euler(new Vector3(0,180,0)))).GetComponentInChildren<SpecialBullet>();
            Instantiate(bulletSpawnEffect, spawnTransforms[i].position, Quaternion.identity);

            b.SetData(answerList[i]);

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void DestroyAllBullet() {
        OnDestroyAllBullet?.Invoke();
        CurBulletCnt = 0;
    }

    private void OnDestroyAnswerBullet(AnswerBullet bullet) {
        CurBulletCnt--;
    }
}
