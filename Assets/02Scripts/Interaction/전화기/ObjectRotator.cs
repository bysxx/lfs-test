using UnityEngine;

public class DialController : MonoBehaviour
{
    public float rotationSpeed = 5f; // �ʴ� ȸ�� �ӵ� (�� ����)
    public bool enableDebugLogs = false; // ����� �α׸� ������� ���θ� �����ϴ� �÷���

    void Update()
    {
        // ���̽�ƽ �Է��� �����ɴϴ� (�¿� ȭ��ǥ Ű �Ǵ� ��Ʈ�ѷ� ���̽�ƽ)
        float rotationInput = Input.GetAxis("Horizontal");

        // �Է¿� ���� ������Ʈ�� ȸ���� ���� �����մϴ�.
        if (rotationInput != 0)
        {
            // ȸ������ ����մϴ�.
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

            // ���� ȸ������ �����ͼ� Y ���� �������� ȸ���� �����մϴ�.
            transform.Rotate(Vector3.up, rotationAmount, Space.World);
        }

        // ����� �αװ� Ȱ��ȭ�� ��� ���� ȸ�� ������ ����մϴ�.
        if (enableDebugLogs)
        {
            Vector3 rotationAngles = transform.rotation.eulerAngles;
            Debug.Log($"ȸ�� - X: {rotationAngles.x}, Y: {rotationAngles.y}, Z: {rotationAngles.z}");
        }
    }
}
