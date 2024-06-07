using UnityEngine;

public class VolumeDial : MonoBehaviour
{
    public float rotationSpeed = 5f; // 회전 속도

    void Update()
    {
        // 조이스틱 입력을 가져옵니다 (상하 화살표 키 또는 컨트롤러 조이스틱)
        float rotationInput = Input.GetAxis("Vertical");

        if (rotationInput != 0)
        {
            // 회전량을 계산합니다.
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

            // 다이얼을 로컬 z 축을 중심으로 회전시킵니다.
            transform.Rotate(Vector3.forward, rotationAmount, Space.Self);
        }
    }
}
