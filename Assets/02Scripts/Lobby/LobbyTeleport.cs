using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyTeleport : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [SerializeField] private int num;
    [SerializeField] private QuestReporter reporter;

    private void OnTriggerEnter(Collider other) {
        if (reporter != null) reporter.Report(0);
        Access.Player.StopPlayer();
        Access.UIM.FadeToScene(SceneName);
    }
}
