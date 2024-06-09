using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class televisionQuesttest : MonoBehaviour
{
    [SerializeField] private Quest televisionQuest;

    // Start is called before the first frame update
    void Start()
    {
        Access.QuestM.Register(televisionQuest);
    }
}