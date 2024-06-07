using UnityEngine;

public class DialController : MonoBehaviour
{
    public float rotationSpeed = 5f; // ȸ�� �ӵ�

    private void Update()
    {
        // ��Ʈ�ѷ��� ���̽�ƽ �Է� ����
        float rotationInput = Input.GetAxis("Horizontal");

        // ���̾� ȸ��
        if (rotationInput != 0)
        {
            // ȸ�� ���⿡ ���� ȸ�� ���� ���
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

            // ������Ʈ�� ���� ���� ���� �������� ȸ�� ����
            transform.Rotate(transform.up, rotationAmount, Space.World);
        }

        // ���� ������Ʈ�� ȸ�� �� �α� ���
        Vector3 rotationAngles = transform.rotation.eulerAngles;
        Debug.Log($"Rotation - X: {rotationAngles.x}, Y: {rotationAngles.y}, Z: {rotationAngles.z}");
    }
}
