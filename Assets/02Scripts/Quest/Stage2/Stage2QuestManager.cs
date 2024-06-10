using UnityEngine;

public class Stage2QuestManager : MonoBehaviour
{
    public GameObject Luna;     // �ʱ� NPC Luna
    public GameObject Luna2;    // �Ŀ� ������ NPC Luna2

    private bool tvQuestCompleted = false;

    void Start()
    {
        // ���� �� luna�� Ȱ��ȭ, luna2�� ��Ȱ��ȭ
        Luna.SetActive(true);
        Luna2.SetActive(false);
    }

    public void CompleteTVQuest()
    {
        tvQuestCompleted = true;
        Debug.Log("TV ����Ʈ �Ϸ��");
        UpdateNPCStates();
    }

    void UpdateNPCStates()
    {
        Debug.Log("NPC ���� ������Ʈ ��. TV ����Ʈ �Ϸ� ���� : " + tvQuestCompleted);
        if (tvQuestCompleted)
        {
            Luna.SetActive(false);
            Luna2.SetActive(true);
            Debug.Log("Luna ��Ȱ��ȭ, Luna2 Ȱ��ȭ");
        }
        else
        {
            Luna.SetActive(true);
            Luna2.SetActive(false);
            Debug.Log("Luna Ȱ��ȭ, Luna2 ��Ȱ��ȭ");
        }
    }
}
