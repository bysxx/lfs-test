using UnityEngine;

public class ChannelDialController : MonoBehaviour
{
    public TVController tvController; // TVController ����
    public float rotationSpeed = 60f; // �ʴ� ȸ�� �ӵ� (�� ����)
    public bool enableDebugLogs = false; // ����� �α׸� ������� ���θ� �����ϴ� �÷���
    public float minRotation = 0f; // �ּ� ȸ�� ����
    public float maxRotation = 360f; // �ִ� ȸ�� ����
    private int[] angleToChannelMapping; // ������ ä�� ����

    private void Start()
    {
        // ������ ä���� ���۾����� �����մϴ�.
        angleToChannelMapping = new int[] { 3, 4, 5, 6, 0, 1, 2 };
    }

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

    }

    void UpdateChannel()
    {
        float currentAngle = transform.rotation.eulerAngles.z;
        int channel = GetChannelFromAngle(currentAngle); // �������� ä���� ���
        tvController.SetChannel(channel); // TVController�� ä�� ����

        if (enableDebugLogs)
        {
            Debug.Log("���� ä��: " + channel); // ����� �α� ���
        }
    }

    int GetChannelFromAngle(float angle)
    {
        // 0 ~ 360 ���� ������ 0 ~ 6 ä�� ������ �����մϴ�.
        int index = Mathf.RoundToInt(angle / 60f) % 6;
        return angleToChannelMapping[index];
    }
}