using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHandler : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private List<GameObject> cars;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        Access.QuestM.OnQuestRegisteredHandler += OnQuestRegistered;

        yield return null;

        tutorialManager.SetNextTutorial();
    }

    private void OnQuestRegistered(Quest quest) {
        cars.ForEach(car => car.SetActive(true));
        Debug.Log("Car is activated");
    }

    private void OnDestroy() {
        Access.QuestM.OnQuestRegisteredHandler -= OnQuestRegistered;
    }
}
