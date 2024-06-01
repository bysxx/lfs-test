using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCarHandler : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        Access.QuestM.OnQuestRegisteredHandler += (quest) => {
            car.SetActive(true);
            Debug.Log("Car is activated");
        };

        Access.QuestM.OnQuestCompletedHandler += (quest) => {
            Access.SceneM.LoadScene("stage2", 3.0f);
        };
    }
}
