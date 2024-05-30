using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Waypoint : MonoBehaviour
{
    public string waypointName; // ��������Ʈ �̸�
    [SerializeField] private TaskTarget target;
    [SerializeField] private Quest quest;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �ڵ����� "Player" �±װ� �ִٰ� ����
        {
            Access.QuestM.ReceiveReport(quest.Category, target, 1);
            Debug.Log("��������");
        }
    }
}
