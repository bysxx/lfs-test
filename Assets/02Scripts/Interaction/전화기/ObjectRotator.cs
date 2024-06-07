using UnityEngine;

public class DialController : MonoBehaviour
{
    public float rotationSpeed = 5f; // �ʴ� ȸ�� �ӵ� (�� ����)
    public bool enableDebugLogs = false; // ����� �α׸� ������� ���θ� �����ϴ� �÷���
    public float minRotation = 0f; // �ּ� ȸ�� ����
    public float maxRotation = 330f; // �ִ� ȸ�� ����
    public float returnSpeed = 50f; // ���̾��� ���� ��ġ�� ���ư��� �ӵ�
    public float inputTimeout = 2f; // �Է��� ���� �ð��� �����ϱ� ���� Ÿ�Ӿƿ� �ð� (�� ����)
    public float[] numberAngles = { 330f, 0f, 30f, 60f, 90f, 120f, 150f, 180f, 210f, 240f, 270f, 300f }; // �� ������ ����

    private float lastInputTime; // ������ �Է� �ð��� ����ϱ� ���� ����
    private Quaternion initialRotation; // �ʱ� ȸ������ �����ϱ� ���� ����

    void Start()
    {
        initialRotation = transform.rotation; // �ʱ� ȸ������ �����մϴ�.
    }

    void Update()
    {
        // ���̽�ƽ �Է��� �����ɴϴ� (�¿� ȭ��ǥ Ű �Ǵ� ��Ʈ�ѷ� ���̽�ƽ)
        float rotationInput = Input.GetAxis("Horizontal");

        if (rotationInput != 0)
        {
            // �Է��� �ִ� ���, ������ �Է� �ð��� ������Ʈ�մϴ�.
            lastInputTime = Time.time;

            // ȸ������ ����մϴ�.
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

            // ���� ȸ������ �����ɴϴ�.
            float currentYRotation = transform.rotation.eulerAngles.y;
            float newYRotation = currentYRotation + rotationAmount;

            // ȸ�� ������ 0������ 360���� ����ϴ�.
            if (newYRotation < 0f)
            {
                newYRotation += 360f;
            }
            else if (newYRotation >= 360f)
            {
                newYRotation -= 360f;
            }

            // ȸ�� ������ �����մϴ�.
            if (newYRotation >= minRotation && newYRotation <= maxRotation)
            {
                transform.Rotate(Vector3.up, rotationAmount, Space.Self);
            }
        }
        else
        {
            // �Է��� ���� Ÿ�Ӿƿ� �ð��� ���� ���, ���̾��� ���� ��ġ�� �����ϴ�.
            if (Time.time - lastInputTime > inputTimeout)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
            }
        }

        // ����� �αװ� Ȱ��ȭ�� ��� ���� ȸ�� ������ ����մϴ�.
        if (enableDebugLogs)
        {
            Vector3 rotationAngles = transform.rotation.eulerAngles;
            Debug.Log($"ȸ�� - X: {rotationAngles.x}, Y: {rotationAngles.y}, Z: {rotationAngles.z}");
        }

        // ��ȣ�� �ν��մϴ�.
        RecognizeNumber();
    }

    void RecognizeNumber()
    {
        float currentAngle = transform.rotation.eulerAngles.y;
        for (int i = 0; i < numberAngles.Length; i++)
        {
            // �־��� ������ ���� ������ ���� ���� �ִ��� Ȯ���մϴ�.
            if (Mathf.Abs(currentAngle - numberAngles[i]) <= 10f || Mathf.Abs(currentAngle - numberAngles[i] + 360f) <= 10f)
            {
                Debug.Log("�νĵ� ����: " + (i + 1)); // �νĵ� ���ڸ� ����մϴ�.
                break;
            }
        }
    }
}
