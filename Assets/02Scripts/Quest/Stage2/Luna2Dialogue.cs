using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luna2Dialogue : MonoBehaviour
{
    public Stage2QuestManager stage2QuestManager;

    void Start()
    {
        // 대화 시작 시 필요한 초기화 작업 수행
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 접촉 시 대화 시작
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        // 대화 시작 로직 구현
        Debug.Log("Luna2와 대화 시작");
    }
}
