using UnityEngine;

public class TVController : MonoBehaviour
{
    private int currentChannel = 0;
    private float volume = 0.5f; // 초기 볼륨 값 설정

    // TV의 채널을 설정하는 메서드
    public void SetChannel(int channel)
    {
        currentChannel = channel;
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