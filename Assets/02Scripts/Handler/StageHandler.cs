using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHandler : MonoBehaviour
{
    [SerializeField] private List<Quest> quests; // 여러 퀘스트를 받을 수 있도록 변경

    // Start is called before the first frame update
    void Start()
    {
        Access.QuestM.OnQuestRegisteredHandler += (quest) => {
            Define.Log($"New Quest:{quest.ID} Registered");
            Define.Log($"Active Quests Count:{Access.QuestM.ActiveQuests.Count}");
        };

        foreach (var quest in quests)
        {
            var newQuest = Access.QuestM.Register(quest);

            newQuest.OnTaskConditionChanged += (quest, task, currentSuccess, prevSuccess) => {
                Define.Log($"Quest:{quest.ID}, Task:{task.ID}, CurrentSuccess:{currentSuccess}");
            };

            newQuest.OnCompleted += (quest) => {
                Define.Log($"Quest:{quest.ID} Completed");
            };
        }
    }
}
