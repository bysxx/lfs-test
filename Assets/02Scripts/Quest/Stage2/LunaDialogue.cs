using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaDialogue : MonoBehaviour
{
    public Stage2QuestManager stage2QuestManager;

    public void OnDialogueEnd()
    {
        // TV ����Ʈ ���� ����
        Debug.Log("Luna���� ��ȭ �Ϸ�, TV ����Ʈ ����");
        stage2QuestManager.CompleteTVQuest();
    }
}
