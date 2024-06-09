using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossQuizState : State {

    public static event Action<Quiz> OnQuizSet; 
    public static event Action OnQuizClosed;

    private BossController bossController;

    [Header("Quiz Info")]
    [SerializeField] private QuizDataBase quizDataBase;
    [SerializeField] private float patternTimer;

    [Header("Bullet Info")]
    [SerializeField] private QuizBullet quizBulletPrefab;
    [SerializeField] private Transform SpawnTransform;

    private bool patternStart = false;
    private Quiz curQuiz;
    private QuizBullet quizBullet;
    private PopUpUI timerUI;
    private QuizDataBase quizData;
    private bool correctBulletTriggered;
    private bool incorrectBulletTriggered;

    private void Start() {
        AnswerBullet.OnCorrectBulletTrigger += OnCorrectBulletTrigger;
        AnswerBullet.OnInCorrectBulletTrigger += OnInCorrectBulletTrigger;
        quizData = Instantiate(quizDataBase);
    }

    private void OnDestroy() {
        AnswerBullet.OnCorrectBulletTrigger -= OnCorrectBulletTrigger;
        AnswerBullet.OnInCorrectBulletTrigger -= OnInCorrectBulletTrigger;
    }

    public override void Activate() {
        if (patternStart) {

            if (correctBulletTriggered) {
                OnQuizClosed?.Invoke();
                curQuiz.isCleared = true;
                bossController.Fsm.Transition(bossController.IdleState);
                return;
            }

            Access.BossStageM.PatternTimer.Accessor -= Time.deltaTime;
            if (Access.BossStageM.PatternTimer.Accessor <= 0 || incorrectBulletTriggered || Access.BossStageM.CurBulletCnt <= 0) {
                OnQuizClosed?.Invoke();
                Access.BossStageM.PatternTimer.Accessor = 0;
                Shot();
                if (!Access.GameM.isTutorialCleared) bossController.Fsm.Transition(bossController.QuizState);
                else bossController.Fsm.Transition(bossController.IdleState);
            }

        }
    }

    public override void Enter(Controller controller) {
        Access.BossStageM.PatternTimer.Accessor = patternTimer;
        bossController = controller as BossController;
        curQuiz = GetRandomQuiz();
        correctBulletTriggered = false;
        incorrectBulletTriggered = false;

        StartCoroutine(SetBullet());
    }

    public override void Exit() {
        bossController = null;
        Access.BossStageM.DestroyAllBullet();
        Access.UIM.ClosePopupUI(timerUI);
        timerUI = null;
        patternStart = false;
    }

    private Quiz GetRandomQuiz() {
        List<Quiz> list = quizData.quizList.FindAll(x => !x.isCleared);
        if (list.Count == 0) return null;
        return list[Random.Range(0, list.Count)];
    }

    private List<Answer> GetAnswerList() {
        List<Answer> list = curQuiz.answerList.FindAll(x => !x.isCorrect);

        System.Random random = new();
        int n = list.Count;

        for (int i = n - 1; i > 0; i--) {
            int j = random.Next(0, i + 1);
            Answer temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        list = list.GetRange(0, 3);
        list.Insert(Random.Range(0,4), curQuiz.answerList.Find(x => x.isCorrect));
        
        return list;
    }

    private IEnumerator SetBullet() {

        yield return new WaitForSeconds(2f);

        bossController.BossAnimator.SetTrigger("CreateQuiz");
        quizBullet = Instantiate(quizBulletPrefab, SpawnTransform.position, Quaternion.identity);

        OnQuizSet?.Invoke(curQuiz);

        yield return new WaitForSeconds(2f);

        BossStageManager.Instance.SpawnSpecialBullet(GetAnswerList());

        timerUI = Access.UIM.ShowPopupUI<PopUpUI>("TimerPanel");
        patternStart = true;
    }

    private void Shot() {
        bossController.BossAnimator.SetTrigger("ShotQuiz");
        quizBullet.Shot((FindObjectOfType<XROrigin>().transform.position - SpawnTransform.position).normalized);
    }

    private void OnCorrectBulletTrigger(AnswerBullet bullet) {
        correctBulletTriggered = true;
        if (!Access.GameM.isTutorialCleared) GetComponent<QuestReporter>().Report(1);
    }

    private void OnInCorrectBulletTrigger(AnswerBullet bullet) {
        incorrectBulletTriggered = true;
    }
}
