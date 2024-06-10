using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2QuestReporterListener : MonoBehaviour
{
    public Stage2QuestManager stage2QuestManager;
    private Stage2QuestReporter stage2questReporter;

    void Start()
    {
        // QuestReporter�� Report �޼ҵ带 �����ϱ� ���� ��������Ʈ�� �߰��մϴ�.
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
        // ��ũ��Ʈ�� �ı��� �� ��������Ʈ�� �����մϴ�.
        if (stage2questReporter != null)
        {
            stage2questReporter.onQuestReported -= OnQuestReported;
        }
    }

    private void OnQuestReported(int questID)
    {
        Debug.Log($"����Ʈ �����: {questID}");

        if (questID == 0) // TV ����Ʈ�� ID�� 0�� ���
        {
            stage2QuestManager.CompleteTVQuest();
        }
    }
}
