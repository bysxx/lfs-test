using UnityEngine;

public class ChannelDialController : MonoBehaviour
{
    public TVController tvController; // TVController ����
    public float rotationSpeed = 60f; // �ʴ� ȸ�� �ӵ� (�� ����)
    public bool enableDebugLogs = false; // ����� �α׸� ������� ���θ� �����ϴ� �÷���
    public float minRotation = 0f; // �ּ� ȸ�� ����
    public float maxRotation = 360f; // �ִ� ȸ�� ����

    private void Update()
    {
        // ���̽�ƽ �Է��� �����ɴϴ� (�¿� ȭ��ǥ Ű �Ǵ� ��Ʈ�ѷ� ���̽�ƽ)
        float rotationInput = Input.GetAxis("Horizontal");

        if (rotationInput != 0)
        {
            // ȸ������ ����մϴ�.
            float rotationAmount = Mathf.Sign(rotationInput) * rotationSpeed * Time.deltaTime;

            // ���� ȸ������ �����ɴϴ�.
            float currentZRotation = transform.rotation.eulerAngles.z;
            float newZRotation = currentZRotation + rotationAmount;

            // ȸ�� ������ 0������ 360���� ����ϴ�.
            if (newZRotation < 0f)
            {
                newZRotation += 360f;
            }
            else if (newZRotation >= 360f)
            {
                newZRotation -= 360f;
            }

            // ȸ�� ������ �����մϴ�.
            if (newZRotation >= minRotation && newZRotation <= maxRotation)
            {
                transform.Rotate(Vector3.forward, rotationAmount, Space.Self);
                UpdateChannel(); // ä�� ������Ʈ
            }
        }

        // ����� �αװ� Ȱ��ȭ�� ��� ���� ȸ�� ������ ����մϴ�.
        if (enableDebugLogs)
        {
            Vector3 rotationAngles = transform.rotation.eulerAngles;
            Debug.Log($"ȸ�� - X: {rotationAngles.x}, Y: {rotationAngles.y}, Z: {rotationAngles.z}");
        }
    }

    void UpdateChannel()
    {
        float currentAngle = transform.rotation.eulerAngles.z;
        int channel = Mathf.RoundToInt(currentAngle / 60f); // 60�� ������ ä�� ���
        tvController.SetChannel(channel); // TVController�� ä�� ����
        if (enableDebugLogs)
        {
            Debug.Log("���� ä��: " + channel); // ����� �α� ���
        }
    }
}
