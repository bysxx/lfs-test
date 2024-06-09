using UnityEngine;

public class DistanceInteraction : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public float interactionDistance = 2f; // ��ȣ�ۿ� �Ÿ�

    private void Update()
    {
        // �÷��̾�� �� ��ü ������ �Ÿ��� ����մϴ�.
        float distance = Vector3.Distance(transform.position, player.position);

        // ���� �Ÿ��� ��ȣ�ۿ� �Ÿ� �̳��� �ִٸ�
        if (distance <= interactionDistance)
        {
            // ���⿡ ��ȣ�ۿ��ϰ��� �ϴ� ������ �߰��մϴ�.
            // ���� ���, Ư�� Ű�� ������ �� ��ȣ�ۿ��ϴ� �ڵ� ���� ���� �� �ֽ��ϴ�.
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    void Interact()
    {
        // �� ��ü�� ��ȣ�ۿ��ϴ� �ڵ带 ���⿡ �߰��մϴ�.
        Debug.Log("��ȣ�ۿ��� �����մϴ�.");
    }
}
