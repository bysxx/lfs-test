using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : Controller, IHitable {

    [Header("Boss Info")]
    [SerializeField] private GameObject deadEffect;
    public DynamicVariable<int> Hp;
    [field : SerializeField] public Animator BossAnimator { get; private set; }

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
    }

    private void OnDestroy() {
        AnswerBullet.OnCorrectBulletTrigger -= OnCorrectBulletTrigger;
    }

    private void Update() {
        Fsm.Update();
    }

    public void Dead() {
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
