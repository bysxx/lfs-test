using UnityEngine;

public class TVController : MonoBehaviour
{
    private int currentChannel = 0;
    private float volume = 0.5f; // �ʱ� ���� �� ����

    // TV�� ä���� �����ϴ� �޼���
    public void SetChannel(int channel)
    {
        currentChannel = channel;
        Debug.Log("���� ä��: " + currentChannel);
    }

    // TV�� ���� ���¸� ��ȯ�ϴ� �޼��� (�׻� ��������)
    public bool IsOn()
    {
        return true;
    }

    // TV�� ������ �����ϴ� �޼���
    public void SetVolume(float newVolume)
    {
        // ������ 0���� 1 ������ ������ �����մϴ�.
        volume = Mathf.Clamp01(newVolume);
        Debug.Log("���� ����: " + volume);
    }
}