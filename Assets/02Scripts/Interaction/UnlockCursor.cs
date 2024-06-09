using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    void Start()
    {
        // 커서가 화면에 표시되고 잠기지 않도록 설정
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // 게임 실행 중에도 계속해서 커서 잠금 해제 상태 유지
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (!Cursor.visible)
        {
            Cursor.visible = true;
        }
    }
}
