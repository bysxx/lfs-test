using UnityEngine;

public class DialController : MonoBehaviour
{
    public float rotationSpeed = 5f; // 초당 회전 속도 (도 단위)
    public bool enableDebugLogs = false; // 디버그 로그를 사용할지 여부를 결정하는 플래그
    public float minRotation = 0f; // 최소 회전 각도
    public float maxRotation = 330f; // 최대 회전 각도
    public float returnSpeed = 50f; // 다이얼이 원래 위치로 돌아가는 속도
    public float inputTimeout = 2f; // 입력이 없는 시간을 추적하기 위한 타임아웃 시간 (초 단위)
    public float[] numberAngles = { 330f, 0f, 30f, 60f, 90f, 120f, 150f, 180f, 210f, 240f, 270f, 300f }; // 각 숫자의 각도

    private float lastInputTime; // 마지막 입력 시간을 기록하기 위한 변수
    private Quaternion initialRotation; // 초기 회전값을 저장하기 위한 변수

    void Start()
    {
        initialRotation = transform.rotation; // 초기 회전값을 저장합니다.
    }

    void Update()
    {
        // 조이스틱 입력을 가져옵니다 (좌우 화살표 키 또는 컨트롤러 조이스틱)
        float rotationInput = Input.GetAxis("Horizontal");

        if (rotationInput != 0)
        {
            // 입력이 있는 경우, 마지막 입력 시간을 업데이트합니다.
            lastInputTime = Time.time;

            // 회전량을 계산합니다.
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

            // 현재 회전값을 가져옵니다.
            float currentYRotation = transform.rotation.eulerAngles.y;
            float newYRotation = currentYRotation + rotationAmount;

            // 회전 범위를 0도에서 360도로 맞춥니다.
            if (newYRotation < 0f)
            {
                newYRotation += 360f;
            }
            else if (newYRotation >= 360f)
            {
                newYRotation -= 360f;
            }

            // 회전 범위를 제한합니다.
            if (newYRotation >= minRotation && newYRotation <= maxRotation)
            {
                transform.Rotate(Vector3.up, rotationAmount, Space.Self);
            }
        }
        else
        {
            // 입력이 없고 타임아웃 시간이 지난 경우, 다이얼을 원래 위치로 돌립니다.
            if (Time.time - lastInputTime > inputTimeout)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
            }
        }

        // 디버그 로그가 활성화된 경우 현재 회전 각도를 기록합니다.
        if (enableDebugLogs)
        {
            Vector3 rotationAngles = transform.rotation.eulerAngles;
            Debug.Log($"회전 - X: {rotationAngles.x}, Y: {rotationAngles.y}, Z: {rotationAngles.z}");
        }

        // 번호를 인식합니다.
        RecognizeNumber();
    }

    void RecognizeNumber()
    {
        float currentAngle = transform.rotation.eulerAngles.y;
        for (int i = 0; i < numberAngles.Length; i++)
        {
            // 주어진 각도가 숫자 각도의 범위 내에 있는지 확인합니다.
            if (Mathf.Abs(currentAngle - numberAngles[i]) <= 10f || Mathf.Abs(currentAngle - numberAngles[i] + 360f) <= 10f)
            {
                Debug.Log("인식된 숫자: " + (i + 1)); // 인식된 숫자를 출력합니다.
                break;
            }
        }
    }
}
