using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReviewPanelUI : SceneUI
{
    [System.Serializable]
    public class QuizReview {
        public Quiz quiz;
        public string explain;
        public Sprite explainImg;

        public QuizReview(Quiz quiz) {
            this.quiz = quiz;
            this.explain = quiz.quizExplain;
            this.explainImg = quiz.quizImg;
        }
    }

    enum Buttons {
        NextBtn,
        PrevBtn,
        OkBtn
    }

    enum TMPs {
        ExplainText
    }

    enum Images {
        ReviewImg
    }

    [SerializeField] private QuizDataBase quizData;
    private List<QuizReview> quizReviews = new List<QuizReview>();
    private int curExplainIdx = -1;


    private void Start() {

        foreach (var quiz in quizData.quizList) {
            QuizReview item = new QuizReview(quiz);
            quizReviews.Add(item);
        }

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(TMPs));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.NextBtn).gameObject.BindEvent(OnNextBtnClicked);
        GetButton((int)Buttons.PrevBtn).gameObject.BindEvent(OnPrevBtnClicked);
        GetButton((int)Buttons.OkBtn).gameObject.BindEvent(OnOkBtnClicked);

        OnNextBtnClicked(null);

        GetButton((int)Buttons.OkBtn).gameObject.SetActive(false);
    }

    private void OnEnable() {
        base.Init();
    }

    private void OnNextBtnClicked(PointerEventData data) {

        if (curExplainIdx >= quizReviews.Count - 1) {
            GetButton((int)Buttons.OkBtn).gameObject.SetActive(true);
            GetTMP((int)TMPs.ExplainText).gameObject.SetActive(false);
            return;
        }

        QuizReview quizReview = quizReviews[++curExplainIdx];
        GetImage((int)Images.ReviewImg).sprite = quizReview.explainImg;
        GetTMP((int)TMPs.ExplainText).text = quizReview.explain;
    }

    private void OnPrevBtnClicked(PointerEventData data) {

        if (curExplainIdx == 0) return;

        if (curExplainIdx >= quizReviews.Count - 1) {
            GetButton((int)Buttons.OkBtn).gameObject.SetActive(false);
            GetTMP((int)TMPs.ExplainText).gameObject.SetActive(true);
        }

        QuizReview quizReview = quizReviews[--curExplainIdx];
        GetImage((int)Images.ReviewImg).sprite = quizReview.explainImg;
        GetTMP((int)TMPs.ExplainText).text = quizReview.explain;
    }

    private void OnOkBtnClicked(PointerEventData data) {
        Access.UIM.FadeToScene("BossScene");
    }
}
