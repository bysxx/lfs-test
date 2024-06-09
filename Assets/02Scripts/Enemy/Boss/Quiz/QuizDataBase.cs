using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz/QuizDataBase", fileName = "QuizDataBase")]
public class QuizDataBase : ScriptableObject {
    public List<Quiz> quizList;
}

[System.Serializable]
public class Quiz {
    public bool isCleared;
    public string quizID;
    public string quizDescription;
    public List<Answer> answerList;

    public string quizExplain;
    public Sprite quizImg;
}

[System.Serializable]
public class Answer {
    public string answerString;
    public bool isCorrect;
}
