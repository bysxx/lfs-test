using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneQuestTest : MonoBehaviour
{
    [SerializeField] private Quest PhoneQuest;

    // Start is called before the first frame update
    void Start()
    {
        Access.QuestM.Register(PhoneQuest);
        Debug.Log("Äù½ºÆ® ¹ÞÀ½");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
