using UnityEngine;
using System.Collections;

public class DialController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public bool enableDebugLogs = false;
    public float minRotation = 0f;
    public float maxRotation = 330f;
    public float returnSpeed = 50f;
    public float inputTimeout = 0.5f;
    public float[] numberAngles = { 330f, 0f, 30f, 60f, 90f, 120f, 150f, 180f, 210f };
    public int[] targetNumberSequence = { 0, 3, 1, 3, 6, 9, 1, 6, 9, 0 };

    private float lastInputTime;
    private bool isMoving = false;
    private int currentIndex = 0;
    private bool isNumberRecognized = false;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        enabled = false; // �ʱ⿡�� ��Ȱ��ȭ ���·� �����մϴ�.
    }

    void Update()
    {
        if (!enabled) return; // Ȱ��ȭ���� �ʾ����� �ƹ� �۾��� ���� �ʽ��ϴ�.

        float rotationInput = Input.GetAxis("Horizontal");

        if (rotationInput != 0)
        {
            lastInputTime = Time.time;
            isMoving = true;

            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
            float currentYRotation = transform.rotation.eulerAngles.y;
            float newYRotation = currentYRotation + rotationAmount;

            if (newYRotation < 0f)
            {
                newYRotation += 360f;
            }
            else if (newYRotation >= 360f)
            {
                newYRotation -= 360f;
            }

            if (newYRotation >= minRotation && newYRotation <= maxRotation)
            {
                transform.Rotate(Vector3.up, rotationAmount, Space.Self);
            }

            isNumberRecognized = false;
        }
        else
        {
            if (Time.time - lastInputTime > inputTimeout)
            {
                isMoving = false;
                if (!isNumberRecognized)
                {
                    RecognizeNumber();
                }
            }
        }
    }

    void RecognizeNumber()
    {
        float currentAngle = transform.rotation.eulerAngles.y;
        for (int i = 0; i < numberAngles.Length; i++)
        {
            if (Mathf.Abs(currentAngle - numberAngles[i]) <= 10f || Mathf.Abs(currentAngle - numberAngles[i] + 360f) <= 10f)
            {
                if ((i == 9 ? 0 : i + 1) != targetNumberSequence[currentIndex])
                {
                    Debug.Log("���ڰ� ����� ��ġ���� �ʽ��ϴ�. �ٽ� �õ��մϴ�.");
                    StartCoroutine(ReturnToInitialPosition());
                    currentIndex = 0;
                    return;
                }

                Debug.Log($"�νĵ� ����: {(i == 9 ? 0 : i + 1)}, ������ �ε���: {currentIndex}, ���� ����: {targetNumberSequence[currentIndex]}");
                CheckNumber(i == 9 ? 0 : i + 1);
                isNumberRecognized = true;
                break;
            }
        }
    }

    void CheckNumber(int number)
    {
        if (number == targetNumberSequence[currentIndex])
        {
            currentIndex++;
            if (currentIndex >= targetNumberSequence.Length)
            {
                Debug.Log("�Ϸ�!");
                StartCoroutine(ReturnToInitialPosition());
                currentIndex = 0;
            }
        }
        else
        {
            currentIndex = 0;
        }
    }

    IEnumerator ReturnToInitialPosition()
    {
        while (Quaternion.Angle(transform.rotation, initialRotation) > 0.01f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
