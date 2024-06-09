using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionQuest : MonoBehaviour
{
    [SerializeField] private Quest TVQuest;

    // Start is called before the first frame update
    void Start()
    {
        Access.QuestM.Register(TVQuest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
