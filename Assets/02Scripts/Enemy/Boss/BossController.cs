using Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : Controller, IHitable {

    [Header("Boss Info")]
    [SerializeField] private GameObject deadEffect;
    public DynamicVariable<int> Hp;
    [field : SerializeField] public Animator BossAnimator { get; private set; }
    [SerializeField] private DialogueGraph bossStartDialogue;
    [SerializeField] private DialogueGraph bossDeadDialogue;
    [SerializeField] private DialogueGraph[] bossRandomDialgues;

    public BossFSM Fsm { get; private set; }
    public State IdleState { get; private set; }
    public State SpawnState { get; private set; }
    public State QuizState { get; private set; }

    private void Awake() {
        IdleState = GetComponent<BossIdleState>();
        SpawnState = GetComponent<BossSpawnState>();
        QuizState = GetComponent<BossQuizState>();
    }

    private void Start() {

        AnswerBullet.OnCorrectBulletTrigger += OnCorrectBulletTrigger;

        Fsm = new BossFSM(this);
        Fsm.Transition(IdleState);

        if (GameManager.Instance.isTutorialCleared) Access.DIalogueM.RegisterDialogue(bossStartDialogue);
    }

    private void OnDestroy() {
        AnswerBullet.OnCorrectBulletTrigger -= OnCorrectBulletTrigger;
    }

    private void Update() {
        Fsm.Update();
    }

    public void Dead() {
        Access.DIalogueM.RegisterDialogue(bossDeadDialogue);
        BossAnimator.SetTrigger("Die");
        GetComponent<QuestReporter>().Report(2);
        Invoke(nameof(DeadEffect), 3.2f);
    }

    public void Hit(int dmg) {
        Hp.Accessor -= dmg;
        if (Hp.Accessor <= 0) {
            Hp.Accessor = 0;
            Dead();
        }
    }

    private void DeadEffect() {
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetPattern(int i) {

        if (GameManager.Instance.isTutorialCleared) Access.DIalogueM.RegisterDialogue(bossRandomDialgues[Random.Range(0, bossRandomDialgues.Length - 1)]);

        switch (i) {
            case 0:
                Fsm.Transition(SpawnState);
                break;
            case 1:
                Fsm.Transition(QuizState);
                break;
        }
    }

    private void OnCorrectBulletTrigger(AnswerBullet bullet) {
        Hit(1);
    }

}
