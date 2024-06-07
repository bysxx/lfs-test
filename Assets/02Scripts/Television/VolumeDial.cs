using UnityEngine;

public class VolumeDial : MonoBehaviour
{
    public float rotationSpeed = 5f; // ȸ�� �ӵ�

    void Update()
    {
        // ���̽�ƽ �Է��� �����ɴϴ� (���� ȭ��ǥ Ű �Ǵ� ��Ʈ�ѷ� ���̽�ƽ)
        float rotationInput = Input.GetAxis("Vertical");

        if (rotationInput != 0)
        {
            // ȸ������ ����մϴ�.
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

            // ���̾��� ���� z ���� �߽����� ȸ����ŵ�ϴ�.
            transform.Rotate(Vector3.forward, rotationAmount, Space.Self);
        }
    }
}
