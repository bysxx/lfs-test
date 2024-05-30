using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Waypoint : MonoBehaviour
{
    public string waypointName; // 웨이포인트 이름
    [SerializeField] private TaskTarget target;
    [SerializeField] private Quest quest;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 자동차에 "Player" 태그가 있다고 가정
        {
            Access.QuestM.ReceiveReport(quest.Category, target, 1);
            Debug.Log("지나갔당");
        }
    }
}
