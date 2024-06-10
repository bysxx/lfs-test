using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2QuestReporterListener : MonoBehaviour
{
    public Stage2QuestManager stage2QuestManager;
    private Stage2QuestReporter stage2questReporter;

    void Start()
    {
        // QuestReporter의 Report 메소드를 감지하기 위해 델리게이트를 추가합니다.
        stage2questReporter = GetComponent<Stage2QuestReporter>();
        if (stage2questReporter != null)
        {
            stage2questReporter.onQuestReported += OnQuestReported;
        }
        else
        {
            Debug.LogError("Stage2QuestReported component is missing on this GameObject");
        }
    }

    void OnDestroy()
    {
        // 스크립트가 파괴될 때 델리게이트를 제거합니다.
        if (stage2questReporter != null)
        {
            stage2questReporter.onQuestReported -= OnQuestReported;
        }
    }

    private void OnQuestReported(int questID)
    {
        Debug.Log($"퀘스트 보고됨: {questID}");

        if (questID == 0) // TV 퀘스트의 ID가 0인 경우
        {
            stage2QuestManager.CompleteTVQuest();
        }
    }
}
