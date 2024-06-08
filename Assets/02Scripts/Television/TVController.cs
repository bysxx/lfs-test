using UnityEngine;

public class TVController : MonoBehaviour
{
    public GameObject[] screens; // �� ä�ο� �ش��ϴ� ȭ�� ������Ʈ �迭
    public Material[] channelMaterials; // �� ä�ο� �ش��ϴ� ���׸��� �迭

    private int currentChannel = 0;
    private float volume = 0.5f; // �ʱ� ���� �� ����

    // TV�� ä���� �����ϴ� �޼���
    public void SetChannel(int channel)
    {
        currentChannel = channel;

        // ���� ä�ο� �ش��ϴ� ȭ�� ������Ʈ�� ���� ��� ���׸����� �Ҵ�
        if (currentChannel >= 0 && currentChannel < screens.Length)
        {
            Renderer screenRenderer = screens[currentChannel].GetComponent<Renderer>();
            if (screenRenderer != null && currentChannel < channelMaterials.Length && channelMaterials[currentChannel] != null)
            {
                screenRenderer.material = channelMaterials[currentChannel];
            }
            else
            {
                Debug.LogError("��ũ�� ������ �Ǵ� ä�� ���׸����� �ùٸ��� �������� �ʾҽ��ϴ�.");
            }
        }
        else
        {
            Debug.LogError("��ȿ���� ���� ä�� ��ȣ�Դϴ�.");
        }

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
