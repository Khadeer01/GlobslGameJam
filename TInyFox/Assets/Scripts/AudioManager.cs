using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public enum Sound
    {
        MaskOn
    }

    [Header("Audio")]
    public AudioSource sfxSource;
    public AudioClip maskOn;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void Play(Sound sound)
    {
        if (Instance == null) return;

        AudioClip clip = Instance.GetClip(sound);
        if (clip != null)
            Instance.sfxSource.PlayOneShot(clip);
    }

    AudioClip GetClip(Sound sound)
    {
        switch (sound)
        {
            case Sound.MaskOn:
                return maskOn;

            default:
                return null;
        }
    }
}
