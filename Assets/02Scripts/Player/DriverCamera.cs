using UnityEngine;

public class DriverCameraFollow : MonoBehaviour
{
    public Transform carTransform; // 자동차의 Transform 컴포넌트
    public Vector3 cameraOffset; // 카메라의 오프셋 값
    public Transform driverSeat; // 운전자 좌석(Transform 컴포넌트)

    void LateUpdate()
    {
        // 자동차의 위치와 회전을 기준으로 카메라 위치 및 회전 업데이트
        transform.position = carTransform.TransformPoint(cameraOffset);
        transform.rotation = driverSeat.rotation;
    }
}
