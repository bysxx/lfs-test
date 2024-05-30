using System.Collections;
using System.Collections.Generic;
using TMPro;

public class QuizPanelUI : ObjectUI
{
    enum TMPs {
        QuizText
    }

    private void Start() {

        BossQuizState.OnQuizSet += OnQuizSet;
        BossQuizState.OnQuizClosed += OnQuizClosed;


        Bind<TextMeshProUGUI>(typeof(TMPs));
        gameObject.SetActive(false);
    }

    private void OnDestroy() {
        BossQuizState.OnQuizSet -= OnQuizSet;
        BossQuizState.OnQuizClosed -= OnQuizClosed;
    }

    private void OnQuizSet(Quiz quiz) {
        gameObject.SetActive(true);
        GetTMP((int)TMPs.QuizText).text = quiz.quizDescription;
    }

    private void OnQuizClosed() {
        gameObject.SetActive(false);
    }
}
