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
        enabled = false; // 초기에는 비활성화 상태로 시작합니다.
    }

    void Update()
    {
        if (!enabled) return; // 활성화되지 않았으면 아무 작업도 하지 않습니다.

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
                    Debug.Log("숫자가 예상과 일치하지 않습니다. 다시 시도합니다.");
                    StartCoroutine(ReturnToInitialPosition());
                    currentIndex = 0;
                    return;
                }

                Debug.Log($"인식된 숫자: {(i == 9 ? 0 : i + 1)}, 시퀀스 인덱스: {currentIndex}, 예상 숫자: {targetNumberSequence[currentIndex]}");
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
                Debug.Log("완료!");
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
