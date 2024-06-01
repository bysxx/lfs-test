using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHandler : MonoBehaviour
{
    [SerializeField] private Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        Access.QuestM.OnQuestCompletedHandler += (quest) => {
            Access.SceneM.LoadScene("stage1-2", 3.0f);
        };
    }
}
