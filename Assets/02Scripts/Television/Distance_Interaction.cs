using UnityEngine;

public class DistanceInteraction : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float interactionDistance = 2f; // 상호작용 거리

    private void Update()
    {
        // 플레이어와 이 객체 사이의 거리를 계산합니다.
        float distance = Vector3.Distance(transform.position, player.position);

        // 만약 거리가 상호작용 거리 이내에 있다면
        if (distance <= interactionDistance)
        {
            // 여기에 상호작용하고자 하는 로직을 추가합니다.
            // 예를 들어, 특정 키를 눌렀을 때 상호작용하는 코드 등을 넣을 수 있습니다.
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    void Interact()
    {
        // 이 객체와 상호작용하는 코드를 여기에 추가합니다.
        Debug.Log("상호작용을 수행합니다.");
    }
}
