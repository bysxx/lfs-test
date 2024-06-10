using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyRelic : MonoBehaviour
{
    [field: SerializeField] public int StageNum { get; private set; }
    [field: SerializeField, Multiline] public string RelicName { get; private set; }
    [field: SerializeField, Multiline] public string RelicExplain { get; private set; }
    [field: SerializeField] public Sprite RelicImage { get; private set; }

    private void Start() {
        if (StageNum < Access.GameM.stageProgress.Length && Access.GameM.stageProgress[StageNum])
            gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
    

}
