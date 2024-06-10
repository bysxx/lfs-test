using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyTeleport : MonoBehaviour
{
    [SerializeField] private string SceneName;

    private void OnTriggerEnter(Collider other) {
        Access.Player.StopPlayer();
        Access.UIM.FadeToScene(SceneName);
    }
}
