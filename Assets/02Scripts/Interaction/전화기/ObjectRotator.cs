using UnityEngine;

public class DialController : MonoBehaviour
{
    public float rotationSpeed = 5f; // 초당 회전 속도 (도 단위)
    public bool enableDebugLogs = false; // 디버그 로그를 사용할지 여부를 결정하는 플래그

    void Update()
    {
        // 조이스틱 입력을 가져옵니다 (좌우 화살표 키 또는 컨트롤러 조이스틱)
        float rotationInput = Input.GetAxis("Horizontal");

        // 입력에 따라 오브젝트의 회전을 직접 조작합니다.
        if (rotationInput != 0)
        {
            // 회전량을 계산합니다.
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

            // 현재 회전값을 가져와서 Y 축을 기준으로 회전을 적용합니다.
            transform.Rotate(Vector3.up, rotationAmount, Space.World);
        }

        // 디버그 로그가 활성화된 경우 현재 회전 각도를 기록합니다.
        if (enableDebugLogs)
        {
            Vector3 rotationAngles = transform.rotation.eulerAngles;
            Debug.Log($"회전 - X: {rotationAngles.x}, Y: {rotationAngles.y}, Z: {rotationAngles.z}");
        }
    }
}
