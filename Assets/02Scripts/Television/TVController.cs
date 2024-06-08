using UnityEngine;

public class TVController : MonoBehaviour
{
    public GameObject[] screens; // 각 채널에 해당하는 화면 오브젝트 배열
    public Material[] channelMaterials; // 각 채널에 해당하는 메테리얼 배열

    private int currentChannel = 0;
    private float volume = 0.5f; // 초기 볼륨 값 설정

    // TV의 채널을 설정하는 메서드
    public void SetChannel(int channel)
    {
        currentChannel = channel;

        // 현재 채널에 해당하는 화면 오브젝트가 있을 경우 메테리얼을 할당
        if (currentChannel >= 0 && currentChannel < screens.Length)
        {
            Renderer screenRenderer = screens[currentChannel].GetComponent<Renderer>();
            if (screenRenderer != null && currentChannel < channelMaterials.Length && channelMaterials[currentChannel] != null)
            {
                screenRenderer.material = channelMaterials[currentChannel];
            }
            else
            {
                Debug.LogError("스크린 렌더러 또는 채널 메테리얼이 올바르게 설정되지 않았습니다.");
            }
        }
        else
        {
            Debug.LogError("유효하지 않은 채널 번호입니다.");
        }

        Debug.Log("현재 채널: " + currentChannel);
    }

    // TV의 전원 상태를 반환하는 메서드 (항상 켜져있음)
    public bool IsOn()
    {
        return true;
    }

    // TV의 볼륨을 설정하는 메서드
    public void SetVolume(float newVolume)
    {
        // 볼륨은 0에서 1 사이의 값으로 제한합니다.
        volume = Mathf.Clamp01(newVolume);
        Debug.Log("현재 볼륨: " + volume);
    }
}
