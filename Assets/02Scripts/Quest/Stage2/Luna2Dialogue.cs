using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luna2Dialogue : MonoBehaviour
{
    public Stage2QuestManager stage2QuestManager;

    void Start()
    {
        // ��ȭ ���� �� �ʿ��� �ʱ�ȭ �۾� ����
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� ���� �� ��ȭ ����
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        // ��ȭ ���� ���� ����
        Debug.Log("Luna2�� ��ȭ ����");
    }
}
