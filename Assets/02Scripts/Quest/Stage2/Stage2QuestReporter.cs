using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2QuestReporter : MonoBehaviour
{
    public delegate void Stage2QuestReportedHandler(int questID);
    public event Stage2QuestReportedHandler onQuestReported;

    public void Report(int questID)
    {
        Debug.Log("����Ʈ ����: " + questID);
        onQuestReported?.Invoke(questID);
    }
}
