using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHandler : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private List<GameObject> cars;

    // Start is called before the first frame update
    void Start()
    {
        Access.QuestM.OnQuestRegisteredHandler += (quest) => {
            cars.ForEach(car => car.SetActive(true));
            Debug.Log("Car is activated");
        };

        Access.QuestM.OnQuestCompletedHandler += (quest) => {
            Access.SceneM.LoadScene("stage1-2", 3.0f);
        };
    }
}
