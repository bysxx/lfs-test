using UnityEngine;

public class DialController : MonoBehaviour
{
    public float rotationSpeed = 5f; // 회전 속도

    private void Update()
    {
        // 컨트롤러의 조이스틱 입력 감지
        float rotationInput = Input.GetAxis("Horizontal");

        // 다이얼 회전
        if (rotationInput != 0)
        {
            // 회전 방향에 따라 회전 각도 계산
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

            // 오브젝트의 로컬 수직 축을 기준으로 회전 적용
            transform.Rotate(transform.up, rotationAmount, Space.World);
        }

        // 현재 오브젝트의 회전 값 로그 출력
        Vector3 rotationAngles = transform.rotation.eulerAngles;
        Debug.Log($"Rotation - X: {rotationAngles.x}, Y: {rotationAngles.y}, Z: {rotationAngles.z}");
    }
}
