using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCarHandler : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private GameObject car;
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private Transform playerSpawnPos;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        Access.QuestM.OnQuestRegisteredHandler += OnQuestRegistered;
        Access.QuestM.OnQuestCompletedHandler += OnQuestCompleted;

        yield return null;

        tutorialManager.SetNextTutorial();
    }

    private void OnQuestRegistered(Quest quest) {
        car.SetActive(true);
        Debug.Log("Car is activated");
    }

    private void OnQuestCompleted(Quest quest) {
        car.SetActive(false);
        Access.Player.transform.position = playerSpawnPos.position;
        Access.Player.transform.rotation = playerSpawnPos.rotation;
    }


    private void OnDestroy() {
        Access.QuestM.OnQuestRegisteredHandler -= OnQuestRegistered;
        Access.QuestM.OnQuestCompletedHandler -= OnQuestCompleted;
    }

}
