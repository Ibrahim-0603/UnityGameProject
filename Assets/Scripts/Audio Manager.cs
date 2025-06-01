using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioMixer audioMixer;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    public AudioClip laserShot;
    public AudioClip enemyDeath;
    public AudioClip gameMusic;
    public AudioClip mainMenuMusic;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip takeDamage;
    public AudioClip buttonPress;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ApplySavedAudioSettings();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void ApplySavedAudioSettings()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        volume = Mathf.Clamp(volume, 0.0001f, 1f); // Avoid Log10(0)
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20f);

        bool sfxEnabled = PlayerPrefs.GetInt("SFX Toggle", 1) == 1;
        audioMixer.SetFloat("SFX", sfxEnabled ? 0f : -80f);

        bool musicEnabled = PlayerPrefs.GetInt("Music Toggle", 1) == 1;
        audioMixer.SetFloat("Music", musicEnabled ? 0f : -80f);
    }
}
