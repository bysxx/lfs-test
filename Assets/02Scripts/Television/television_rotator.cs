using UnityEngine;

public class ChannelDialController : MonoBehaviour
{
    public TVController tvController; // TVController 참조
    public float rotationSpeed = 60f; // 초당 회전 속도 (도 단위)
    public bool enableDebugLogs = false; // 디버그 로그를 사용할지 여부를 결정하는 플래그
    public float minRotation = 0f; // 최소 회전 각도
    public float maxRotation = 360f; // 최대 회전 각도

    private void Update()
    {
        // 조이스틱 입력을 가져옵니다 (좌우 화살표 키 또는 컨트롤러 조이스틱)
        float rotationInput = Input.GetAxis("Horizontal");

        if (rotationInput != 0)
        {
            // 회전량을 계산합니다.
            float rotationAmount = Mathf.Sign(rotationInput) * rotationSpeed * Time.deltaTime;

            // 현재 회전값을 가져옵니다.
            float currentZRotation = transform.rotation.eulerAngles.z;
            float newZRotation = currentZRotation + rotationAmount;

            // 회전 범위를 0도에서 360도로 맞춥니다.
            if (newZRotation < 0f)
            {
                newZRotation += 360f;
            }
            else if (newZRotation >= 360f)
            {
                newZRotation -= 360f;
            }

            // 회전 범위를 제한합니다.
            if (newZRotation >= minRotation && newZRotation <= maxRotation)
            {
                transform.Rotate(Vector3.forward, rotationAmount, Space.Self);
                UpdateChannel(); // 채널 업데이트
            }
        }

        // 디버그 로그가 활성화된 경우 현재 회전 각도를 기록합니다.
        if (enableDebugLogs)
        {
            Vector3 rotationAngles = transform.rotation.eulerAngles;
            Debug.Log($"회전 - X: {rotationAngles.x}, Y: {rotationAngles.y}, Z: {rotationAngles.z}");
        }
    }

    void UpdateChannel()
    {
        float currentAngle = transform.rotation.eulerAngles.z;
        int channel = Mathf.RoundToInt(currentAngle / 60f); // 60도 단위로 채널 계산
        tvController.SetChannel(channel); // TVController에 채널 설정
        if (enableDebugLogs)
        {
            Debug.Log("현재 채널: " + channel); // 디버그 로그 출력
        }
    }
}
