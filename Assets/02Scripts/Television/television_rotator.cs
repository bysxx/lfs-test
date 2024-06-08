using UnityEngine;

public class ChannelDialController : MonoBehaviour
{
    public TVController tvController; // TVController ����
    public float rotationSpeed = 60f; // �ʴ� ȸ�� �ӵ� (�� ����)
    public bool enableDebugLogs = false; // ����� �α׸� ������� ���θ� �����ϴ� �÷���
    public float minRotation = 0f; // �ּ� ȸ�� ����
    public float maxRotation = 360f; // �ִ� ȸ�� ����
    private int[] angleToChannelMapping; // ������ ä�� ����
    private int previousChannel = -1; // ���� ä���� �����ϴ� ����

    private void Start()
    {
        // ������ ä���� ���۾����� �����մϴ�.
        angleToChannelMapping = new int[] { 3, 4, 5, 6, 0, 1, 2 };
    }

    private void Update()
    {
        // ���� Ű�е� �Է��� �����ɴϴ�
        if (Input.GetKey(KeyCode.Keypad1))
        {
            RotateDial(-1); // �������� ȸ��
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            RotateDial(1); // ���������� ȸ��
        }
    }

    private void RotateDial(int direction)
    {
        // ȸ������ ����մϴ�.
        float rotationAmount = direction * rotationSpeed * Time.deltaTime;

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

    void UpdateChannel()
    {
        float currentAngle = transform.rotation.eulerAngles.z;
        int channel = GetChannelFromAngle(currentAngle); // �������� ä���� ���
        if (channel != previousChannel)
        {
            tvController.SetChannel(channel); // TVController�� ä�� ����
            previousChannel = channel; // ���� ä���� ���� ä�η� ������Ʈ

            if (enableDebugLogs)
            {
                Debug.Log("���� ä��: " + channel); // ����� �α� ���
            }
        }
    }

    int GetChannelFromAngle(float angle)
    {
        // 0 ~ 360 ���� ������ 0 ~ 6 ä�� ������ �����մϴ�.
        int index = Mathf.RoundToInt(angle / 51f) % 7;
        return angleToChannelMapping[index];
    }
}