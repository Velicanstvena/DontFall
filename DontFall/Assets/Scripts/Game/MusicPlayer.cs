using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();

        if (PlayerPrefsController.GetMasterVolume() == 0f)
        {
            audioSource.volume = 0.8f;
            PlayerPrefsController.SetMasterVolume(0.8f);
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
