using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Waypoint : MonoBehaviour
{
    public string waypointName; // ��������Ʈ �̸�
    [SerializeField] private TaskTarget target;
    [SerializeField] private Category category;
    [SerializeField] private GameObject particleEffect;

    private bool isPassed;

    void OnTriggerEnter(Collider other)
    {
        if (!isPassed && other.CompareTag("Player")) // �ڵ����� "Player" �±װ� �ִٰ� ����
        {
            Access.QuestM.ReceiveReport(category, target, 1);
            particleEffect.SetActive(false);
            isPassed = true;
        }
    }
}
