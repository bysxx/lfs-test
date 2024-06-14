using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] teleports;
    [SerializeField] private TutorialManager tutorialManager;

    private IEnumerator Start() {
        
        yield return null;

        tutorialManager.SetNextTutorial();
    }
}
