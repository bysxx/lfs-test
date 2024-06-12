using Dialogue;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueGraph[] dialogues;

    private void Start() {
        if (!Array.Exists(dialogues, x => x.IsAcceptable)) gameObject.SetActive(false);
    }

    private List<DialogueGraph> GetAvailable() {

        List<DialogueGraph> results = new List<DialogueGraph>();

        foreach (DialogueGraph dialogue in dialogues) {
            if (dialogue.IsAcceptable) results.Add(dialogue);
        }

        return results;
    }

    private void Provide() {

        List<DialogueGraph> results = GetAvailable();

        if (results.Count == 0) return;

        if (results.Count == 1) Access.DIalogueM.RegisterDialogue(results[0]);
        else Access.DIalogueM.RegisterDialogue(results);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Provide();
            Access.Player.StopOnlyMove();
            gameObject.SetActive(false);
        }
    }
}
