using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

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
}
