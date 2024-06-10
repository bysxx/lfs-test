using UnityEngine;

public class Stage2QuestManager : MonoBehaviour
{
    public GameObject Luna;     // 초기 NPC Luna
    public GameObject Luna2;    // 후에 등장할 NPC Luna2

    private bool tvQuestCompleted = false;

    void Start()
    {
        // 시작 시 luna는 활성화, luna2는 비활성화
        Luna.SetActive(true);
        Luna2.SetActive(false);
    }

    public void CompleteTVQuest()
    {
        tvQuestCompleted = true;
        Debug.Log("TV 퀘스트 완료됨");
        UpdateNPCStates();
    }

    void UpdateNPCStates()
    {
        Debug.Log("NPC 상태 업데이트 중. TV 퀘스트 완료 여부 : " + tvQuestCompleted);
        if (tvQuestCompleted)
        {
            Luna.SetActive(false);
            Luna2.SetActive(true);
            Debug.Log("Luna 비활성화, Luna2 활성화");
        }
        else
        {
            Luna.SetActive(true);
            Luna2.SetActive(false);
            Debug.Log("Luna 활성화, Luna2 비활성화");
        }
    }
}
