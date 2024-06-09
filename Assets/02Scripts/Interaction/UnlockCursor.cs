using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    void Start()
    {
        // Ŀ���� ȭ�鿡 ǥ�õǰ� ����� �ʵ��� ����
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // ���� ���� �߿��� ����ؼ� Ŀ�� ��� ���� ���� ����
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
