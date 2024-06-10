using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaDialogue : MonoBehaviour
{
    public Stage2QuestManager stage2QuestManager;

    public void OnDialogueEnd()
    {
        // TV 퀘스트 생성 로직
        Debug.Log("Luna와의 대화 완료, TV 퀘스트 시작");
        stage2QuestManager.CompleteTVQuest();
    }
}
