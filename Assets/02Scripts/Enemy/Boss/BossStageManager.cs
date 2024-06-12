using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class BossStageManager : NormalSingleton<BossStageManager>
{
    public delegate void OnDestroyAllBulletHandler();
    public static event OnDestroyAllBulletHandler OnDestroyAllBullet;

    [Header("Game Info")]
    [SerializeField] private Transform playerSpawnPos;
    [SerializeField] private DialogueGraph endStageTalk;

    [Header("Tutorial")]
    [SerializeField] private TutorialManager tutorialManager;
    public DynamicVariable<float> PatternTimer { get; set; }

    [Header("Boss Info")]
    [SerializeField] private GameObject bossSpawnEffect;
    [SerializeField] private BossController bossPrefab;
    [SerializeField] private Vector3 bossSpawnPos;

    [Header("Gun Info")]
    [SerializeField] private GameObject gunSpawnEffect;
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunSpawnPos;

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

    private IEnumerator Start() {

        AnswerBullet.OnDestroyBullet += OnDestroyAnswerBullet;

        yield return null;

        if (!GameManager.Instance.isTutorialCleared) tutorialManager.SetNextTutorial();
        else StartCoroutine(BossStageStart_CO());
    }

    private void OnDestroy() {
        AnswerBullet.OnDestroyBullet -= OnDestroyAnswerBullet;
        endStageTalk.RemoveEventAtEventNode("EndStageEvent", EndStageEvent);
    }

    public GunWeapon GunSpawn() {
        Instantiate(gunSpawnEffect, gunSpawnPos.position, Quaternion.identity);
        GunWeapon gun = Instantiate(gunPrefab, gunSpawnPos.position, Quaternion.identity).GetComponent<GunWeapon>();
        return gun;
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

    public IEnumerator BossStageStart_CO() {
        Access.UIM.FadeOut();

        Access.Player.StopPlayer();

        yield return new WaitForSeconds(3f);

        if (bossController != null) Destroy(bossController.gameObject);
        if (Access.Player.P_DInfo.CurGunWeapon != null) Destroy(Access.Player.P_DInfo.CurGunWeapon.gameObject);
        Access.Player.transform.position = playerSpawnPos.position;
        Access.Player.transform.rotation = playerSpawnPos.rotation;

        Access.UIM.FadeIn();

        yield return new WaitForSeconds(3f);

        Access.Player.MovePlayer();
        GunSpawn().CanShot = true;

        yield return new WaitForSeconds(2f);

        Access.BossStageM.SpawnBoss();

    }

    public void EndBossStage() {
        endStageTalk.BindEventAtEventNode("EndStageEvent", EndStageEvent);
        Access.DIalogueM.RegisterDialogue(endStageTalk);
    }

    private void EndStageEvent() {
        Access.GameM.curStage = 3;
        Access.GameM.stageProgress[2] = true;
        Access.UIM.FadeToScene("LobbyScene");
    }

}
