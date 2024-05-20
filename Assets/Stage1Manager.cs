using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : MonoBehaviour
{
    [SerializeField] private Quest quest;
    // Start is called before the first frame update
    void Start()
    {
        Access.QuestM.OnQuestRegisteredHandler += (quest) => {
            Define.Log($"New Quest:{quest.ID} Registered");
            Define.Log($"Active Quests Count:{Access.QuestM.ActiveQuests.Count}");
        };

        var newQuest = Access.QuestM.Register(quest);

        newQuest.OnTaskConditionChanged += (quest, task, currentSuccess, prevSuccess) => {
            Define.Log($"Quest:{quest.ID}, Task:{task.ID}, CurrentSuccess:{currentSuccess}");
        };

        newQuest.OnCompleted += (quest) => {
            Define.Log($"Quest:{quest.ID} Completed");
        };
    }
}
