using UnityEngine;

public class TVController : MonoBehaviour
{
    private bool isOn = false;
    private int currentChannel = 1;
    private float currentVolume = 0.5f;

    public GameObject screen; 
    public AudioSource audioSource; 
    public Material offMaterial; 
    public Material[] channelMaterials; 

    private MeshRenderer screenRenderer;

    void Start()
    {
        if (screen != null)
        {
            screenRenderer = screen.GetComponent<MeshRenderer>();
        }
    }

    public void SetPower(float rotationValue)
    {
        isOn = rotationValue > 180; 
        UpdateTV();
    }

    public void SetChannel(float rotationValue)
    {
        currentChannel = Mathf.FloorToInt(rotationValue / 60) + 1; 
        UpdateTV();
    }

    public void SetVolume(float rotationValue)
    {
        currentVolume = rotationValue / 360; 
        UpdateTV();
    }

    private void UpdateTV()
    {
        if (isOn)
        {
            Debug.Log("TV On - Channel: " + currentChannel + " Volume: " + currentVolume);
            if (screenRenderer != null && currentChannel > 0 && currentChannel <= channelMaterials.Length)
            {
                screenRenderer.material = channelMaterials[currentChannel - 1];
            }
            if (audioSource != null)
            {
                audioSource.volume = currentVolume;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
        else
        {
            Debug.Log("TV Off");
            if (screenRenderer != null)
            {
                screenRenderer.material = offMaterial; 
            }
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
